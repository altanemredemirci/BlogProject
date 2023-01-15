using BlogProject.Entity.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL
{
    public class BusinessLayerResult<T> where T:class
    {
        public List<ErrorMessageObj> Errors { get; set; } //hata mesajları tutan bir liste
        public T Result { get; set; }            //hataların hangi modele ait olduğunu tutan bir generic model

        public BusinessLayerResult()
        {
            Errors = new List<ErrorMessageObj>();
        }

        public void AddError(ErrorMessageCode code, string message)
        {
            Errors.Add(new ErrorMessageObj { Code = code, Message = message });
        }
    }
}
