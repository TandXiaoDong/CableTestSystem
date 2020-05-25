/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				IBaseManager.cs
 *      Description:
 *				 业务逻辑基础接口
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年05月25日
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Business
{
    using CableTestManager.Data;
    public interface IBaseManager<T> : IBaseDBService<T>
    {

    }
}
