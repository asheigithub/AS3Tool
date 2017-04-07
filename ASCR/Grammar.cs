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
                string _math = Properties.Resources.Math;
                var tree = grammar.ParseTree(_math, ASTool.AS3LexKeywords.LEXKEYWORDS,
                            ASTool.AS3LexKeywords.LEXSKIPBLANKWORDS, "Math.as3");

                if (grammar.hasError)
                {
                    return null;
                }
                trees.Add(new compiler.utils.Tuple<ASTool.GrammerTree, string>(tree, "Math.as3"));
            }


            foreach (var tree in trees)
            {
                var analyser = new ASTool.AS3FileGrammarAnalyser(lib, tree.item2);
                if (!analyser.Analyse(grammar, tree.item1)) //生成项目的语法树
                {
                    return null;
                }
            }

            return lib;
        }

    }
}
