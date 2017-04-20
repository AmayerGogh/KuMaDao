﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amayer.Com.Entity;

namespace Amayer.Com.Com
{
    class EventH
    {
        public delegate int DoEventHandler(System.Windows.Forms.FormCollection fc);
        public static Result TryDoSomething(DoEventHandler db, FormCollection fc)
        {
            var result = new Result();
            try
            {
                result.Status = db(fc);
            }
            catch (Exception ex)
            {
                throw ex;
                //result.Status = -1;
                //result.Message = ex.ToString();
            }
            return result;
        }

        public delegate int DoEventHandler1(int id);
        public static Result TryDoSomething(DoEventHandler1 db, int id)
        {
            var result = new Result();
            try
            {
                result.Status = db(id);
            }
            catch (Exception ex)
            {
                result.Status = -1;
                result.Message = ex.ToString();
            }
            return result;
        }
        public delegate int DoEventHandlers(Object o);
        public Result TryDoSomething(DoEventHandlers db, Object o)
        {
            var result = new Result();
            try
            {
                result.Status = db(o);
            }
            catch (Exception ex)
            {
                result.Status = -1;
                result.Message = ex.ToString();
            }
            return result;
        }
    }
}