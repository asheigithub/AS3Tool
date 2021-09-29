﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ASCompiler
{
    public class Grammar
    {
        public static ASTool.Grammar getGrammar()
        {
            ASTool.Lex lex = new ASTool.Lex(null);
            var words = lex.GetWords(Properties.Resources.PG1);
            
            ASTool.Grammar grammar = new ASTool.Grammar(words);
            return grammar;
        }

        public static ASTool.AS3.AS3Proj makeLibProj()
        {
            var lib = new ASTool.AS3.AS3Proj();
            var grammar = getGrammar();

            List<compiler.utils.Tuple<ASTool.GrammerTree, string>> trees = new List<compiler.utils.Tuple<ASTool.GrammerTree, string>>();

            {
                string _Object = Properties.Resources.Object;
                //***类库源码***
                var tree = grammar.ParseTree(_Object, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "Object.as3");
                
                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add ( new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "Object.as3"));
            }

            {
                string _Class = Properties.Resources.Class;
                //***类库源码***
                var tree = grammar.ParseTree(_Class, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "Class.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "Class.as3"));
            }

            {
                string _int = Properties.Resources._int;
                var tree = grammar.ParseTree(_int, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "int.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "int.as3"));
            }

            {
                string _uint = Properties.Resources._uint;
                var tree = grammar.ParseTree(_uint, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "uint.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "uint.as3"));
            }
			{
				string _array = Properties.Resources.Array;
				var tree = grammar.ParseTree(_array, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "Array.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "Array.as3"));
			}
			{
                string _number = Properties.Resources.Number;
                var tree = grammar.ParseTree(_number, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "Number.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "Number.as3"));
            }

            {
                string _function = Properties.Resources.Function;
                var tree = grammar.ParseTree(_function, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "Function.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "Function.as3"));
            }

            

            {
                string _boolean = Properties.Resources.Boolean;
                var tree = grammar.ParseTree(_boolean, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "Boolean.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "Boolean.as3"));
            }

            {
                string _string = Properties.Resources.String;
                var tree = grammar.ParseTree(_string, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "String.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "String.as3"));
            }

            {
                string _buildin_ = Properties.Resources.__buildin__;
                var tree = grammar.ParseTree(_buildin_, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "@__buildin__.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "@__buildin__.as3"));
            }

			{
				string Endian = Properties.Resources.Endian;

				var tree = grammar.ParseTree(Endian, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/utils/Endian.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/utils/Endian.as3"));
			}
			{
				string IDataInput = Properties.Resources.IDataInput;

				var tree = grammar.ParseTree(IDataInput, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/utils/IDataInput.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/utils/IDataInput.as3"));
			}
			{
				string IDataInput2 = Properties.Resources.IDataInput2;

				var tree = grammar.ParseTree(IDataInput2, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/utils/IDataInput2.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/utils/IDataInput2.as3"));
			}
			{
				string IDataOutput = Properties.Resources.IDataOutput;

				var tree = grammar.ParseTree(IDataOutput, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/utils/IDataOutput.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/utils/IDataOutput.as3"));
			}
			{
				string IDataOutput2 = Properties.Resources.IDataOutput2;

				var tree = grammar.ParseTree(IDataOutput2, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/utils/IDataOutput2.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/utils/IDataOutput2.as3"));
			}
			{
				string IExternalizable = Properties.Resources.IExternalizable;

				var tree = grammar.ParseTree(IExternalizable, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/utils/IExternalizable.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/utils/IExternalizable.as3"));
			}

			{
				string ByteArray = Properties.Resources.ByteArray;

				var tree = grammar.ParseTree(ByteArray, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/utils/ByteArray.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/utils/ByteArray.as3"));
			}

			{
				string getDefinitionByName = Properties.Resources.getDefinitionByName;

				var tree = grammar.ParseTree(getDefinitionByName, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/utils/getDefinitionByName.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/utils/getDefinitionByName.as3"));
			}
			{
				string getQualifiedClassName = Properties.Resources.getQualifiedClassName;

				var tree = grammar.ParseTree(getQualifiedClassName, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/utils/getQualifiedClassName.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/utils/getQualifiedClassName.as3"));
			}
			{
                string _math = Properties.Resources.Math;
                var tree = grammar.ParseTree(_math, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "Math.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "Math.as3"));
            }
			{
				string RegExp = Properties.Resources.RegExp;
				var tree = grammar.ParseTree(RegExp, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "RegExp.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "RegExp.as3"));
			}
			{
                string _error = Properties.Resources.Error;
                var tree = grammar.ParseTree(_error, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "Error.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "Error.as3"));
            }

            {
                string _error = Properties.Resources.TypeError;
                var tree = grammar.ParseTree(_error, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "TypeError.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "TypeError.as3"));
            }

			{
				string _error = Properties.Resources.ReferenceError;
				var tree = grammar.ParseTree(_error, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "ReferenceError.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "ReferenceError.as3"));
			}

			{
                string _error = Properties.Resources.ArgumentError;
                var tree = grammar.ParseTree(_error, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "ArgumentError.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "ArgumentError.as3"));
            }
            {
                string _error = Properties.Resources.AneError;
                var tree = grammar.ParseTree(_error, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "AneError.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "AneError.as3"));
            }

			{
				string _error = Properties.Resources.IllegalOperationError;
				var tree = grammar.ParseTree(_error, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/errors/IllegalOperationError.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/errors/IllegalOperationError.as3"));
			}

			{
				string _error = Properties.Resources.IOError;
				var tree = grammar.ParseTree(_error, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/errors/IOError.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/errors/IOError.as3"));
			}
			{
				string _error = Properties.Resources.EOFError;
				var tree = grammar.ParseTree(_error, ASTool.AS3LexKeywords.LEXKEYWORDS,
							ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/errors/EOFError.as3");

				if (grammar.hasError)
				{
					return null;
				}
				trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/errors/EOFError.as3"));
			}
			{
                string _date = Properties.Resources.Date;
                var tree = grammar.ParseTree(_date, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "Date.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "Date.as3"));
            }

            {
                string _dictionary = Properties.Resources.Dictionary;
                var tree = grammar.ParseTree(_dictionary, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "flash/utils/Dictionary.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/utils/Dictionary.as3"));
            }

            {
                string _ienumerator = Properties.Resources.IEnumerator;
                var tree = grammar.ParseTree(_ienumerator, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "system/collections/IEnumerator.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "system/collections/IEnumerator.as3"));
            }

            {
                string _ienumerable = Properties.Resources.IEnumerable;
                var tree = grammar.ParseTree(_ienumerable, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "system/collections/IEnumerable.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "system/collections/IEnumerable.as3"));
            }

            {
                string _yield = Properties.Resources.YieldIterator;
                var tree = grammar.ParseTree(_yield, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "@YieldIterator.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "@YieldIterator.as3"));
            }

            {
                string _sprite = Properties.Resources.Sprite;
                var tree = grammar.ParseTree(_sprite, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "Sprite.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "flash/display/Sprite.as3"));
            }


            foreach (var tree in trees)
            {
                var analyser = new ASTool.AS3FileGrammarAnalyser(lib, tree.item2);
                if (!analyser.Analyse( tree.item1)) //生成项目的语法树
                {
                    return null;
                }
            }


            for (int i = 0; i < lib.SrcFiles.Count; i++)
            {
                if (lib.SrcFiles[i].Package.MainClass !=null && lib.SrcFiles[i].Package.MainClass.Name == "__buildin__")
                {
                    lib.SrcFiles[i].Package.MainClass.Name = "@__buildin__";
                }

				

				if (lib.SrcFiles[i].Package.MainClass != null && lib.SrcFiles[i].Package.MainClass.Name == "YieldIterator")
                {
                    lib.SrcFiles[i].Package.MainClass.Name = "@YieldIterator";
                }
            }

            return lib;
        }

    }
}
