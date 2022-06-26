using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entities.Messages
{
    public enum ErrorMessageCode
    {
        UsernameAlreadyExists = 101,
        EmailAlreadyExists = 102,
        UserIsNotActive = 151,
        UsernameOrPassWrong = 152,
        CheckYourEail = 153,
        UserAlreadyActivate = 154,
        ActivateIdDoesNotExists = 155,
        UserIsNotFound = 156
    }
}
