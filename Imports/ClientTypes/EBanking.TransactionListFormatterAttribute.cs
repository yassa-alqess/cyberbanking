using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace cyberbanking.EBanking;

public partial class TransactionListFormatterAttribute : CustomFormatterAttribute
{
    public const string Key = "cyberbanking.EBanking.TransactionListFormatter";

    public TransactionListFormatterAttribute()
        : base(Key)
    {
    }
}