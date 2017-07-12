using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortal.DAL;
using JobPortal.Models;

namespace JobPortal.BLL
{
    public class SettingsManager
    {
        SettingsGetway settingsGetway = new SettingsGetway();

        public string UpdateSeekerPassword(Settings settings, string mail)
        {
            string message = "Password Change Failed !!";
            if (mail == settings.Email)
            {
                bool isSeekerMailExist = settingsGetway.IsSeekerEmail(settings);
                if (isSeekerMailExist)
                {
                    int isChange = settingsGetway.UpdateSeekerPassword(settings);
                    if (isChange > 0)
                    {
                        message = "Password Change Successfully";
                    }
                }
                else
                {
                    message = "Please enter valid email !!";
                }

            }
            else
            {
                message = "Please enter valid email !!";
            }

            return message;
        }

        public string UpdateEmployerPassword(Settings settings, string mail)
        {
            string message = "Password Change Failed !!";
            if (mail == settings.Email)
            {
                bool isEmployerMailExist = settingsGetway.IsEmployerEmail(settings);
                if (isEmployerMailExist)
                {
                    int isChange = settingsGetway.UpdateEmployerPassword(settings);
                    if (isChange > 0)
                    {
                        message = "Your Password is Changed";
                    }
                }
                else
                {
                    message = "Please enter valid email !!";
                }
            }
            else
            {
                message = "Please enter valid email !!";
            }

            return message;
        }
    
    }
}