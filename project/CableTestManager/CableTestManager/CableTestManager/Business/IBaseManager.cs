/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				IBaseManager.cs
 *      Description:
 *				 ҵ���߼������ӿ�
 *      Author:
 *				��С��
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020��05��25��
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
