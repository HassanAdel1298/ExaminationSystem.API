﻿
using ExaminationSystem.API.VerticalSlicing.Common.Enums;

namespace ExaminationSystem.API.VerticalSlicing.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public BusinessException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
