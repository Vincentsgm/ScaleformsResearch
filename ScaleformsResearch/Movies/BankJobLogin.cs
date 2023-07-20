using RAGENativeUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class BankJobLogin : Movie
    {
        public override string MovieName => "BANK_JOB_LOGIN";
        public string LoginTitle { set => Localization.SetText("HTD_LOGIN_TITLE", value); }
        protected override void OnTestStart()
        {
            LoginTitle = "Scan your hand to identify yourself";
            base.OnTestStart();
        }
    }
}
