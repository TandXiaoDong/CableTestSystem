/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				IBaseManager.cs
 *      Description:
 *				 业务逻辑基础接口
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年06月12日
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business
{
    using CableTestManager.Data;
    public interface IBaseManager<T> : IBaseService<T>
    {

    }
}
