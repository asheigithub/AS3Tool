﻿using System;
using System.Collections.Generic;
using System.Text;


namespace ASCompiler.compiler
{
    using rt = ASBinCode.RunTimeDataType;
    
    class TypeReader
    {
        /// <summary>
        /// 从源代码的类型字符串中转换成运行时类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static ASBinCode.RunTimeDataType fromSourceCodeStr(
            string t,
            ASTool.Token token,
            Builder builder
            )
        {
            if (t == "*" || t == "void")
            {
                return rt.rt_void;
            }
            else if (t == "Boolean")
            {
                return rt.rt_boolean;
            }
            else if (t == "int")
            {
                return ASBinCode.RunTimeDataType.rt_int;
            }
            else if (t == "uint")
            {
                return ASBinCode.RunTimeDataType.rt_uint;
            }
            else if (t == "Number")
            {
                return ASBinCode.RunTimeDataType.rt_number;
            }
            else if (t == "String")
            {
                return ASBinCode.RunTimeDataType.rt_string;
            }
            else if (t == "Function")
            {
                return ASBinCode.RunTimeDataType.rt_function;
            }
            else if (t == "Array")
            {
                return rt.rt_array;
            }
            else
            {
                
                //***查找类定义***
                var found = findClassFromImports(t, builder,token);
                

                if (found.Count == 1)
                {
                    return found[0].getRtType(); // ASBinCode.RunTimeDataType.unknown;
                }
                else if (found.Count > 1)
                {
                    throw new BuildException(token.line, token.ptr, token.sourceFile,
                        "类型" + t + "不明确."
                    );
                }
                else
                {

                    throw new BuildException(token.line, token.ptr, token.sourceFile,
                        "类型" + t + "未实现"
                        );
                }
            }
        }

        public static List<ASBinCode.rtti.Class> findClassFromImports(string t,
            Builder builder,ASTool.Token token)
        {
            List<ASBinCode.rtti.Class> result = new List<ASBinCode.rtti.Class>();

            if (!builder.isEval)
            {
                if (t.StartsWith("Vector.<"))
                {
                    ASBinCode.rtti.Class outvectortype = null;
                    t = builder.build_vector(t, token,out outvectortype);    //如果是Vector,则先编译Vector类

                    result.Add(outvectortype);
                    return result;
                }
            }

            


            //***查找类定义***
            //if (builder._buildingClass.Count > 0)
            //{
            //    //***查找是否是当前类的包外类
            //    var cls = builder._buildingClass.Peek();
            //    if (cls.mainClass == null)
            //    {
            //        //***查找当前类的包外类***
            //        foreach (var item in builder.buildingclasses)
            //        {
            //            if (item.Value.mainClass == cls)
            //            {
            //                if (item.Value.name.Equals(cls.name + "$" + t, StringComparison.Ordinal))
            //                {
            //                    result.Add(item.Value);
            //                    //return ASBinCode.RunTimeDataType.unknown;
            //                }
            //            }
            //        }
            //    }
            //}

            if (builder._currentImports.Count > 0)
            {
                //**查找当前导入的类
                var imports = builder._currentImports.Peek();
                
                for (int i = 0; i < imports.Count; i++)
                {
					if (imports[i].isPackageFunction)
						continue;
					if (t.IndexOf(".") > -1 && !t.StartsWith("Vector.<")) //完全限定名
                    {
                        if ((imports[i].package + "." + imports[i].name).Equals(t, StringComparison.Ordinal))
                        {
                            result.Add(imports[i]);
                        }
                    }
                    else
                    {
                        string name = imports[i].name;
                        
                        if (name.Equals(t, StringComparison.Ordinal))
                        {
                            result.Add(imports[i]);
                        }
                    }
                }

                

            }



            return result;
        }

		public static List<ASBinCode.rtti.Class> findClassFromProject(string t,
			Builder builder, ASTool.Token token)
		{
			List<ASBinCode.rtti.Class> result = new List<ASBinCode.rtti.Class>();

			if (!builder.isEval)
			{
				if (t.StartsWith("Vector.<"))
				{
					ASBinCode.rtti.Class outvectortype = null;
					t = builder.build_vector(t, token, out outvectortype);    //如果是Vector,则先编译Vector类

					result.Add(outvectortype);
					return result;
				}
			}
			
			if (builder.buildingclasses.Count > 0)
			{
				//在所有类中查找
				List<ASBinCode.rtti.Class> imports = new List<ASBinCode.rtti.Class>();
				foreach (var item in builder.buildingclasses)
				{
					imports.Add(item.Value);
				}


				for (int i = 0; i < imports.Count; i++)
				{
					if (imports[i].isPackageFunction)
						continue;

					if (t.IndexOf(".") > -1 && !t.StartsWith("Vector.<")) //完全限定名
					{
						if ((imports[i].package + "." + imports[i].name).Equals(t, StringComparison.Ordinal))
						{
							result.Add(imports[i]);
						}
					}
					else
					{
						string name = imports[i].name;

						if (name.Equals(t, StringComparison.Ordinal))
						{
							result.Add(imports[i]);
						}
					}
				}



			}



			return result;
		}



		public static List<ASBinCode.rtti.Class> findPackageFunctionFromImports(string t,
			Builder builder, ASTool.Token token)
		{
			List<ASBinCode.rtti.Class> result = new List<ASBinCode.rtti.Class>();

			if (!builder.isEval)
			{
				if (t.StartsWith("Vector.<"))
				{
					return result;
				}
			}
			
			if (builder._currentImports.Count > 0)
			{
				//**查找当前导入的类
				var imports = builder._currentImports.Peek();

				for (int i = 0; i < imports.Count; i++)
				{
					if (!imports[i].isPackageFunction)
						continue;

					if (t.IndexOf(".") > -1 && !t.StartsWith("Vector.<")) //完全限定名
					{
						if ((imports[i].package + "." + imports[i].name).Equals(t, StringComparison.Ordinal))
						{
							result.Add(imports[i]);
						}
					}
					else
					{
						string name = imports[i].name;

						if (name.Equals(t, StringComparison.Ordinal))
						{
							result.Add(imports[i]);
						}
					}
				}



			}



			return result;
		}



		public static List<ASBinCode.rtti.Class> findPackageFunction(string t,
			Builder builder, ASTool.Token token)
		{
			List<ASBinCode.rtti.Class> result = new List<ASBinCode.rtti.Class>();

			if (!builder.isEval)
			{
				if (t.StartsWith("Vector.<"))
				{
					return result;
				}
			}

			if (builder.buildingclasses.Count > 0)
			{
				//在所有类中查找
				List<ASBinCode.rtti.Class> imports = new List<ASBinCode.rtti.Class>();
				foreach (var item in builder.buildingclasses)
				{
					imports.Add(item.Value);
				}


				for (int i = 0; i < imports.Count; i++)
				{
					if (!imports[i].isPackageFunction)
						continue;

					if (t.IndexOf(".") > -1 && !t.StartsWith("Vector.<")) //完全限定名
					{
						if ((imports[i].package + "." + imports[i].name).Equals(t, StringComparison.Ordinal))
						{
							result.Add(imports[i]);
						}
					}
					else
					{
						string name = imports[i].name;

						if (name.Equals(t, StringComparison.Ordinal))
						{
							result.Add(imports[i]);
						}
					}
				}



			}



			return result;
		}

	}
}
