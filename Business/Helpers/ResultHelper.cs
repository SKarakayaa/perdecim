using System.Collections.Generic;
using Core.Utilities.Messages;
using Core.Utilities.Results;

namespace Business.Helpers
{
    public static class ResultHelper<T>
    {
        public static IResult ResultReturn(int result)
        {
            if (result == 0)
                return new ErrorResult(CRUDMessages.CreateMessage);
            return new SuccessResult();
        }

        public static IDataResult<T> DataResultReturn(T data)
        {
            if (data == null)
                return new ErrorDataResult<T>(CRUDMessages.NoRecords);
            return new SuccessDataResult<T>(data);
        }

        public static IDataResult<List<T>> DataResultReturn(List<T> datas)
        {
            if (datas.Count == 0)
                return new ErrorDataResult<List<T>>(CRUDMessages.NoRecords);
            return new SuccessDataResult<List<T>>(datas);
        }
    }
}