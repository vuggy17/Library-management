﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    public delegate void ChangePageHandler(string page);

    //new form is show --> opacity mainform decrease
    public delegate void ToggleFormDialogNotifyHandler();
}