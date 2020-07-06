using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OTPGenerator
/// </summary>
public class OTPGenerator
    {
    public OTPGenerator()
        {
        //
        // TODO: Add constructor logic here
        //
        }
    public string GenerateOTP(string numbers)
        {

        string otp = string.Empty;
        for (int i = 0; i < 6; i++)
            {
            string character = string.Empty;
            do
                {
                int index = new Random().Next(0, numbers.Length);
                character = numbers.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
            otp += character;
            }

        return otp;
        }
    }