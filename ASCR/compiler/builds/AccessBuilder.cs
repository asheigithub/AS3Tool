﻿using ASBinCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASCompiler.compiler.builds
{
    class AccessBuilder
    {
        public void buildAccess(CompileEnv env, ASTool.AS3.Expr.AS3ExprStep step, Builder builder)
        {
            if (step.OpCode == ".")
            {
                if (step.Arg1.IsReg)
                {
                    ASBinCode.IRightValue v1 = ExpressionBuilder.getRightValue(env, step.Arg2, step.token, builder);
                    //ASBinCode.IRightValue v2 = ExpressionBuilder.getRightValue(env, step.Arg3, step.token, builder);
                    if (v1 is ASBinCode.StaticClassDataGetter)
                    {
                        if (step.Arg3.Data.FF1Type == ASTool.AS3.Expr.FF1DataValueType.identifier)
                        {
                            ASBinCode.StaticClassDataGetter sd = (ASBinCode.StaticClassDataGetter)v1;
                            var cls = sd._class;

                            build_class(env, step, v1, cls, builder);


                        }
                        else
                        {
                            throw new BuildException(
                                new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                "静态成员名期待一个identifier"));
                        }
                    }
                    else if (v1 is PackagePathGetter)
                    {
                        if (step.Arg3.Data.FF1Type == ASTool.AS3.Expr.FF1DataValueType.identifier)
                        {
                            PackagePathGetter pd = (PackagePathGetter)v1;
                            string path = pd.path + "." + step.Arg3.Data.Value.ToString();

                            //**尝试查找类***

                            //查找导入的类
                            var found = TypeReader.findClassFromImports(path, builder);
                            if (found.Count == 1)
                            {
                                var item = found[0];

                                OpStep stepInitClass = new OpStep(OpCode.init_staticclass,
                                    new SourceToken(step.token.line, step.token.ptr, step.token.sourceFile));
                                stepInitClass.arg1 = new ASBinCode.rtData.RightValue(
                                    new ASBinCode.rtData.rtInt(item.classid));
                                stepInitClass.arg1Type = item.staticClass.getRtType();
                                env.block.opSteps.Add(stepInitClass);

                                ASBinCode.Register eax = env.createASTRegister(step.Arg1.Reg.ID);
                                eax.setEAXTypeWhenCompile(item.getRtType());

                                OpStep op = new OpStep(OpCode.assigning, new SourceToken(step.token.line, step.token.ptr, step.token.sourceFile));
                                op.reg = eax;
                                op.arg1 = new StaticClassDataGetter(item.staticClass);
                                op.arg1Type = item.staticClass.getRtType();

                                env.block.opSteps.Add(op);
                            }
                            else if (found.Count > 1)
                            {
                                throw new BuildException(step.token.line, step.token.ptr, step.token.sourceFile,
                                        "类型" + path + "不明确."
                                    );
                            }
                            else
                            {
                                //没找到
                                PackagePathGetter g = new PackagePathGetter(path);
                                ASBinCode.Register eax = env.createASTRegister(step.Arg1.Reg.ID);
                                eax.setEAXTypeWhenCompile(RunTimeDataType.unknown);
                                eax._pathGetter = g;
                            }
                        }
                        else
                        {
                            throw new BuildException(
                                new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                "静态成员名期待一个identifier"));
                        }
                    }
                    else if (v1 is ThisPointer && v1.valueType == RunTimeDataType.rt_void)
                    {
                        //throw new BuildException(
                        //   new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                        //   "动态查找成员 还没弄"));

                        if (step.Arg3.Data.FF1Type == ASTool.AS3.Expr.FF1DataValueType.identifier)
                        {
                            build_dot_name(env, step, v1);

                        }
                        else
                        {
                            throw new BuildException(
                                   new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                   "静态成员名期待一个identifier"));
                        }


                    }
                    else if (v1.valueType == RunTimeDataType.unknown)
                    {
                        throw new BuildException(
                                   new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                   "遇到了unknown类型"));
                    }
                    else if (v1.valueType > RunTimeDataType.unknown)
                    {
                        ASBinCode.rtti.Class cls = builder.getClassByRunTimeDataType(v1.valueType);

                        if (cls == null)
                        {
                            throw new BuildException(
                                new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                "编译异常 类型" + v1.valueType + "未找到"));
                        }
                        else
                        {
                            build_class(env, step, v1, cls, builder);

                        }
                    }
                    else
                    {
                        if (v1.valueType != RunTimeDataType.rt_void && v1.valueType < RunTimeDataType.unknown)
                        {
                            if (builder.bin.primitive_to_class_table[v1.valueType] != null)
                            {
                                var cls = builder.bin.primitive_to_class_table[v1.valueType];
                                v1 = ExpressionBuilder.addCastOpStep(env, v1, builder.bin.primitive_to_class_table[v1.valueType].getRtType(),
                                    new SourceToken(step.token.line,step.token.ptr,step.token.sourceFile)
                                    , builder
                                    );
                                build_class(env, step, v1, cls, builder);
                            }
                            else
                            {
                                throw new BuildException(
                                           new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                           "基础类型" + v1.valueType + "无法转换为引用类型"));
                            }
                        }
                        else
                        {
                            if (step.Arg3.Data.FF1Type == ASTool.AS3.Expr.FF1DataValueType.identifier)
                            {
                                build_dot_name(env, step, v1);
                            }
                            else
                            {
                                throw new BuildException(
                                       new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                       "静态成员名期待一个identifier"));
                            }
                        }
                    }
                }
                else
                {
                    throw new BuildException(
                            new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                            "编译异常 此处应该是个寄存器"));
                }
            }
            else if (step.OpCode == "[") //和.作用相同
            {
                if (step.Arg1.IsReg)
                {
                    ASBinCode.IRightValue v1 = ExpressionBuilder.getRightValue(env, step.Arg2, step.token, builder);
                    if (v1 is ASBinCode.StaticClassDataGetter)
                    {
                        build_bracket_access(env, step, v1, builder);
                    }
                    else if (v1 is PackagePathGetter)
                    {
                        if (step.Arg3.Data.FF1Type == ASTool.AS3.Expr.FF1DataValueType.identifier)
                        {
                            PackagePathGetter pd = (PackagePathGetter)v1;
                            string path = pd.path + "." + step.Arg3.Data.Value.ToString();

                            //**尝试查找类***

                            //查找导入的类
                            var found = TypeReader.findClassFromImports(path, builder);
                            if (found.Count == 1)
                            {
                                var item = found[0];

                                OpStep stepInitClass = new OpStep(OpCode.init_staticclass,
                                    new SourceToken(step.token.line, step.token.ptr, step.token.sourceFile));
                                stepInitClass.arg1 = new ASBinCode.rtData.RightValue(
                                    new ASBinCode.rtData.rtInt(item.classid));
                                stepInitClass.arg1Type = item.staticClass.getRtType();
                                env.block.opSteps.Add(stepInitClass);

                                ASBinCode.Register eax = env.createASTRegister(step.Arg1.Reg.ID);
                                eax.setEAXTypeWhenCompile(item.getRtType());

                                OpStep op = new OpStep(OpCode.assigning, new SourceToken(step.token.line, step.token.ptr, step.token.sourceFile));
                                op.reg = eax;
                                op.arg1 = new StaticClassDataGetter(item.staticClass);
                                op.arg1Type = item.staticClass.getRtType();

                                env.block.opSteps.Add(op);

                                build_bracket_access(env, step, v1, builder);
                            }
                            else
                            {
                                throw new BuildException(step.token.line, step.token.ptr, step.token.sourceFile,
                                        "类型" + path + "不明确."
                                    );
                            }

                        }
                        else
                        {
                            throw new BuildException(
                                new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                "静态成员名期待一个identifier"));
                        }
                    }
                    else if (v1 is ThisPointer && v1.valueType == RunTimeDataType.rt_void)
                    {
                        if (step.Arg3.Data.FF1Type == ASTool.AS3.Expr.FF1DataValueType.identifier)
                        {
                            build_bracket_access(env, step, v1, builder);
                        }
                        else
                        {
                            throw new BuildException(
                                   new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                   "静态成员名期待一个identifier"));
                        }


                    }
                    else if (v1.valueType == RunTimeDataType.unknown)
                    {
                        throw new BuildException(
                                   new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                   "遇到了unknown类型"));
                    }
                    else if (v1.valueType > RunTimeDataType.unknown)
                    {
                        ASBinCode.rtti.Class cls = builder.getClassByRunTimeDataType(v1.valueType);

                        if (cls == null)
                        {
                            throw new BuildException(
                                new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                "编译异常 类型" + v1.valueType + "未找到"));
                        }
                        else
                        {
                            //**todo**检查如果是数组的情况****

                            build_bracket_access(env, step, v1, builder);

                        }
                    }
                    else
                    {
                        if (v1.valueType != RunTimeDataType.rt_void && v1.valueType < RunTimeDataType.unknown
                            )
                        {
                            if (builder.bin.primitive_to_class_table[v1.valueType] != null)
                            {
                                v1 = ExpressionBuilder.addCastOpStep(env, v1, builder.bin.primitive_to_class_table[v1.valueType].getRtType(),
                                    new SourceToken(step.token.line, step.token.ptr, step.token.sourceFile)
                                    , builder
                                    );
                                build_bracket_access(env, step, v1, builder);
                            }
                            else
                            {
                                throw new BuildException(
                                           new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                                           "基础类型" + v1.valueType + "无法转换为引用类型"));
                            }
                        }
                        else
                        {
                            build_bracket_access(env, step, v1, builder);
                        }
                    }
                }
                else
                {
                    throw new BuildException(
                            new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                            "编译异常 此处应该是个寄存器"));
                }
            }
            else
            {
                throw new BuildException(
                            new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                            "不支持的操作类型 " + step.Type + " " + step.OpCode));
            }
        }

        private static void build_class(CompileEnv env, ASTool.AS3.Expr.AS3ExprStep step, IRightValue v1, ASBinCode.rtti.Class cls, Builder builder)
        {
            if (step.Arg3.Data.FF1Type == ASTool.AS3.Expr.FF1DataValueType.identifier)
            {
                ASBinCode.rtti.ClassMember member = null;
                //***查找对象成员***
                member = MemberFinder.findClassMember(cls, step.Arg3.Data.Value.ToString(), env, builder);

                if (member == null)
                {
                    if (cls.dynamic
                        &&
                        cls.staticClass != null //***编译时检查不能向Class动态加属性。
                        )
                    {
                        //***此处编译为动态属性***
                        build_dot_name(env, step, v1);
                        return;
                    }
                }

                if (member == null)
                {
                    throw new BuildException(
                       new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                       cls.name + "对象成员" + step.Arg3.Data.Value + "未找到"));
                }
                if (!member.isConst && env.isEval)
                {
                    throw new BuildException(
                       new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                       "Eval时忽略非Const成员"));
                }

                build_dot(env, step, v1, member);


            }
            else
            {
                throw new BuildException(
                    new BuildError(step.token.line, step.token.ptr, step.token.sourceFile,
                    "静态成员名期待一个identifier"));
            }
        }

        public static void make_dotStep(CompileEnv env, ASBinCode.rtti.ClassMember member, ASTool.Token token,
            Register eax, IRightValue rvObj
            )
        {
            OpStep op = new OpStep(
                member.bindField is ClassMethodGetter ?
                OpCode.access_method
                :
                OpCode.access_dot

                , new SourceToken(token.line, token.ptr, token.sourceFile));
            op.reg = eax;
            op.regType = eax.valueType;
            op.arg1 = rvObj;
            op.arg1Type = rvObj.valueType;
            op.arg2 = (IRightValue)member.bindField; //new ASBinCode.rtData.RightValue(new ASBinCode.rtData.rtInt(member.index));
            op.arg2Type = member.valueType; //RunTimeDataType.rt_int;

            env.block.opSteps.Add(op);
        }

        private static void build_dot(CompileEnv env, ASTool.AS3.Expr.AS3ExprStep step, IRightValue v1, ASBinCode.rtti.ClassMember member)
        {
            ASBinCode.Register eax = env.createASTRegister(step.Arg1.Reg.ID);
            eax._regMember = member;
            eax._regMemberSrcObj = v1;

            eax.setEAXTypeWhenCompile(member.valueType);

            make_dotStep(env, member, step.token, eax, v1);

            //OpStep op = new OpStep(
            //    member.bindField is ClassMethodGetter?
            //    OpCode.access_method
            //    :
            //    OpCode.access_dot

            //    , new SourceToken(step.token.line, step.token.ptr, step.token.sourceFile));
            //op.reg = eax;
            //op.regType = eax.valueType;
            //op.arg1 = v1;
            //op.arg1Type = v1.valueType;
            //op.arg2 = (IRightValue)member.bindField; //new ASBinCode.rtData.RightValue(new ASBinCode.rtData.rtInt(member.index));
            //op.arg2Type = member.valueType; //RunTimeDataType.rt_int;

            //env.block.opSteps.Add(op);
        }


        private static void build_dot_name(CompileEnv env, ASTool.AS3.Expr.AS3ExprStep step, IRightValue v1)
        {
            ASBinCode.Register eax = env.createASTRegister(step.Arg1.Reg.ID);
            eax.setEAXTypeWhenCompile(RunTimeDataType.rt_void);

            OpStep op = new OpStep(OpCode.access_dot_byname, new SourceToken(step.token.line, step.token.ptr, step.token.sourceFile));
            op.reg = eax;
            op.regType = eax.valueType;
            op.arg1 = v1;
            op.arg1Type = v1.valueType;
            op.arg2 = new ASBinCode.rtData.RightValue(
                new ASBinCode.rtData.rtString(step.Arg3.Data.Value.ToString()));
            op.arg2Type = RunTimeDataType.rt_string;
            env.block.opSteps.Add(op);
        }

        private static void build_bracket_access(CompileEnv env, ASTool.AS3.Expr.AS3ExprStep step, IRightValue v1, Builder builder)
        {
            ASBinCode.Register eax = env.createASTRegister(step.Arg1.Reg.ID);
            eax.setEAXTypeWhenCompile(RunTimeDataType.rt_void);

            var v2 = ExpressionBuilder.getRightValue(env, step.Arg3, step.token, builder);

            if (v1.valueType == RunTimeDataType.rt_void
                )
            {
                OpStep op = new OpStep(OpCode.bracket_access, new SourceToken(step.token.line, step.token.ptr, step.token.sourceFile));
                op.reg = eax;
                op.regType = eax.valueType;
                op.arg1 = v1;
                op.arg1Type = v1.valueType;
                op.arg2 = v2;
                op.arg2Type = v2.valueType;


                env.block.opSteps.Add(op);
            }
            else
            {
               
                OpStep op = new OpStep(OpCode.access_dot_byname, new SourceToken(step.token.line, step.token.ptr, step.token.sourceFile));
                op.reg = eax;
                op.regType = eax.valueType;
                op.arg1 = v1;
                op.arg1Type = v1.valueType;
                op.arg2 = v2;
                op.arg2Type = v2.valueType;
                env.block.opSteps.Add(op);
            }

        }

        
    }
}
