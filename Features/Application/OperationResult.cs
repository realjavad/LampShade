﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Application
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public OperationResult()
        {
            IsSuccess = false;
        }
        public OperationResult Success(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccess = true;
            Message = message;
            return this;
        }
        public OperationResult Failed(string message)
        {
            IsSuccess = false;
            Message = message;
            return this;
        }
    }
}
