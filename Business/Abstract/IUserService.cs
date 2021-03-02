using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;


namespace Business.Abstract
{
   public  interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

        IDataResult<User> GetById(int userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        User GetByMail(string email);
    }
}
