using BlossomInstitute.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlossomInstitute.Application.DataBase.Password.ForgotPassword
{
    public interface IForgotPasswordCommand
    {
        Task<BaseResponseModel> Execute(ForgotPasswordModel model);
    }
}
