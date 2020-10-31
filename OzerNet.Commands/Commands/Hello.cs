using System.Collections.Generic;
using OzerNet.Commands.Infrastructure;

namespace OzerNet.Commands.Commands
{
    [Describe(Module.User, Process.Create, "Makale listesi"), AuthorizedAttribute]
    public class Hello : Command
    {
        [RequiredValidation(ErrorMessage = "İsim zorunludur.")]
        public string Name { get; set; }

        //[MinLengthValidation(MinLength = 10, ErrorMessage = "Telefon numarası en az {0} karakter olmalı.")]
        public string MobilePhoneNumber { get; set; }

        //[MaxLengthValidation(MaxLength = 10, ErrorMessage = "Tc Kimlik numarası en fazla {0} karakter olmalı.")]
        public string Tckno { get; set; }

        //[MinNumberValidation(MinNumber = 2, ErrorMessage = "Müşteri numarası {0}'den küçük olamaz.")]
        public string CustomerNo { get; set; }

        //[MaxNumberValidation(MaxNumber = 4, ErrorMessage = "Bölge numarası {0}'den büyük olamaz.")]
        public string RegionNo { get; set; }

        //[MinItemValidation(MinItemCount = 4, ErrorMessage = "İsim listesi en az {0} adet olmalı.")]
        public List<string> Names { get; set; }

        //[MaxItemValidation(MaxItemCount = 1, ErrorMessage = "Şehir listesi en fazla {0} adet olmalı.")]
        public List<int> Cities { get; set; }
    }
}
