﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ASBinCode
{
    public abstract class NativeFunctionBase
    {
        public abstract string name { get; }
        /// <summary>
        /// 参数定义
        /// </summary>
        public abstract List<RunTimeDataType> parameters { get; }
        /// <summary>
        /// 返回类型定义
        /// </summary>
        public abstract RunTimeDataType returnType { get; }

        public abstract bool isMethod { get; }
        
        public IClassFinder bin { get; set; }

        /// <summary>
        /// 指示是否同步完成
        /// </summary>
        public virtual bool isAsync
        {
            get { return false; }
        }
        

        /// <summary>
        /// 调用函数
        /// </summary>
        /// <param name="thisObj"></param>
        /// <returns></returns>
        public abstract IRunTimeValue execute(rtData.rtObject thisObj,ISLOT[] argements,out string errormessage,out int errorno);

        public virtual void executeAsync(rtData.rtObject thisObj,ISLOT[] argements,ISLOT resultSlot , 
            object callbacker ,object stackframe,
            SourceToken token,IRunTimeScope scope)
        {

        }
    }
}
