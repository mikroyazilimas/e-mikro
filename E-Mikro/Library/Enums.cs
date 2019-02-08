using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro
{
    public enum InputMode
    {
        Unknown,
        Class,
        Parameters
    }

    public enum PageTemplate
    {
        Main = 1,
        Detail = 2,
        DetailWithSidebar = 3,
        Static = 4,
        Contact = 5,
        DetailWithSideMenu = 6
    }

    public enum PageComponent
    {
        ContactForm = 1,
        ProductList = 2,
        RegisterForm = 3,
        NewsMikro = 4,
        News = 5,
        LogoAndImages = 6,
        Video = 7,
        Campaigns = 8,
        FAQ = 9,
        Search = 10,
        ProductRequestForm = 11
    }

    public enum NewsType
    {
        BasindaMikro = 1,
        BasinBulteni = 2
    }

    public enum NavigationType
    {
        Header = 1,
        Footer = 2
    }
}