using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PMDS.Global
{

    public static class StringOperate
    {

        public static string htmlEnter = "<br/>";
        public static string htmlSpace = "&edsp;";
        public static string htmlLine = "<hr/>";




        public static string GetDir(string File)
        {
            try
            {
                if(IsNull(File))return "";

                //int pos = 1;
                //int pos_Prev = 0;
                //bool Apport = false;
                //while (pos != 0)
                //{
                //    pos = File..IndexOf("\\", pos + 1);
                //    //pos = Microsoft.VisualBasic.InStr(pos + 1, File, "\", CompareMethod.Text)
                //    if (pos != 0) pos_Prev = pos;
                //}

                int pos_Prev = File.LastIndexOf("\\");

                if (pos_Prev > 0)
                    return File.Substring(0, pos_Prev);
                else
                    return "";
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
                //return "";
            }
        }
        public static string exeptionToStr(Exception ex)
        {
            string ret = "";
            //ret += "Message:<br/>" + ex.Message + "<br/><br/>";
            //ret += "SourceName:<br/>" + ex.Source  + "<br/><br/>";
            //ret += "StackTrace:<br/>" + ex.StackTrace + "<br/><br/>";
            //ret += "InnerException:<br/>" + ex.InnerException + "<br/><br/>";
            //ret += "TargetSite:<br/>" + ex.TargetSite + "<br/><br/>";
            return ex.ToString ();
        }
        public static string GetDirURL(string File)
        {
            try
            {
                if (IsNull(File)) return "";

                // int pos = 1;
                // int pos_Prev = 0;
                // bool Apport  = false;
                // while (pos != 0)
                // {
                //    //pos = Microsoft.VisualBasic.InStr(pos + 1, File, "/", CompareMethod.Text)
                //    if (pos != 0) pos_Prev = pos;
                // }

                //if (pos_Prev > 0)
                //    return "";// Microsoft.VisualBasic.Left(File, pos_Prev);
                //else
                //    return "";

                int pos_Prev = File.LastIndexOf("/");

                if (pos_Prev > 0)
                    return File.Substring(0, pos_Prev);
                else
                    return "";
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
                //return "";
            }
        }

        public static string GetFileName(string File)
        {
            try
            {
                if (IsNull(File)) return "";

                //int pos = 1;
                //int pos_Prev = 0;
                //bool Apport  = false;
                //while (pos != 0)
                //{
                //    //pos = Microsoft.VisualBasic.InStr(pos + 1, File, "\\", CompareMethod.Text)
                //    if (pos != 0) pos_Prev = pos;
                //}

                //if (pos_Prev > 0)
                //    return "";// Microsoft.VisualBasic.Right(File, Microsoft.VisualBasic.Len(File) - (pos_Prev));
                //else
                //    return "";

                int pos_Prev = File.LastIndexOf("\\");

                if (pos_Prev > 0)
                    return File.Substring(pos_Prev, File.Length - pos_Prev);
                else
                    return "";
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
                //return "";
            }

        }

        public static string GetFiletyp(string File)
        {
            try
            {
                if (IsNull(File)) return "";

                //int pos = 1;
                //int pos_Prev = 0;
                //bool Apport  = false;
                //while (pos != 0)
                //{
                //    //pos = Microsoft.VisualBasic.InStr(pos + 1, File, ".", CompareMethod.Text);
                //    if (pos != 0) pos_Prev = pos;
                //}

                //if (pos_Prev > 0)
                //    return "";// Microsoft.VisualBasic.Right(File, Microsoft.VisualBasic.Len(File) - ((pos_Prev) - 1));
                //else
                //    return "";

                int pos_Prev = File.LastIndexOf(".");

                if (pos_Prev > 0)
                    return File.Substring(pos_Prev, File.Length - pos_Prev);
                else
                    return "";
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
                //return "";
            }

        }

        public static bool IsNull(object Obj)
        {
            bool IsNull = true;

            if (object.Equals(null, Obj) || object.Equals(System.DBNull.Value, Obj) || object.Equals("", Obj))
                IsNull = true;
            else
            {
                if (Obj.GetType().ToString() == "System.Guid")
                {
                    if (object.Equals(null, Obj) || object.Equals(System.DBNull.Value, Obj) || object.Equals("", Obj))
                        IsNull = true;
                    else
                    {
                        if (Obj.ToString() == Guid.Empty.ToString())
                            IsNull = true;
                        else
                            IsNull = false;
                    }
                }
                else if (Obj.GetType().ToString() == "System.String")
                {
                    if (object.Equals(null, ((string)Obj).Trim()) || object.Equals(System.DBNull.Value, ((string)Obj).Trim()) || object.Equals("", ((string)Obj).Trim()))
                        IsNull = true;
                    else
                    {
                        if (Obj.ToString() == Guid.Empty.ToString())
                            IsNull = true;
                        else
                            IsNull = false;
                    }
                }
                else if (Obj.GetType().ToString() == "System.DateTime")
                {
                    if (object.Equals(null, Obj) || object.Equals(System.DBNull.Value, Obj) || Object.Equals("", Obj))
                        IsNull = true;
                    else
                    {
                        DateTime dt = (DateTime)Obj;
                        if (dt.Year == 1 && dt.Month == 1 && dt.Day == 1 )
                            IsNull = true;
                        else
                            IsNull = false;
                    }
                }
                else
                {
                    if (object.Equals(null, Obj) || object.Equals(System.DBNull.Value, Obj) || Object.Equals("", Obj))
                        IsNull = true;
                    else
                        IsNull = false;
                }
            }

            return IsNull;
        }

        public static string addProtDetail(string txt, eTextTyp typ, int anzEnter, string webLink, int stufe   )
        {
            string protDetail = "";
            try
            {
                if (txt != "")
                {
                    if (typ == eTextTyp.überschrift1)
                    {
                        //StringOperate.überschrift1Nr += 1;
                        protDetail += "<span style=" + (char)34 + "color:Black; font-weight:normal; text-decoration:none; font-size:+1;" + (char)34 + ">";
                        //protDetail += StringOperate.überschrift1Nr.ToString() + ".";
                        protDetail += txt;
                        protDetail += "</span>";
                        
                        protDetail += "<span style=" + (char)34 + "color:Black; font-weight:bold; font-size:+0;" + (char)34 + ">";
                        protDetail += "</span>";
                    }
                    else if (typ == eTextTyp.überschrift2)
                    {
                        protDetail += "<span style=" + (char)34 + "color:Black; font-weight:bold; font-size:+0;" + (char)34 + ">";
                        for (int i = 0; i < 3; i++)
                            protDetail += StringOperate.htmlSpace;
                        protDetail +=   txt;
                        protDetail += "</span>";
                    }
                    else if (typ == eTextTyp.überschrift3)
                    {
                        //StringOperate.überschrift3Nr += 1;
                        for (int i = 0; i < 8; i++)
                            protDetail += StringOperate.htmlSpace;
                        //protDetail += StringOperate.überschrift3Nr.ToString() + ".";
                        protDetail += txt;
                    }
                    else if (typ == eTextTyp.txt)
                    {
                        for (int i = 0; i < 17; i++)
                            protDetail += StringOperate.htmlSpace;
                        protDetail += txt;
                    }
                    else if (typ == eTextTyp.link)
                    {
                        //protDetail += "<a title=" + (char)34 + txt + (char)34 + " href=" + (char)34 + webLink + (char)34 + ">" + txt + "</a><br/>";
                    }
                    else if (typ == eTextTyp.line)
                    {
                        protDetail += StringOperate.htmlLine;
                    }

                }

                for (int i = 0; i < anzEnter; i++)
                    protDetail += StringOperate.htmlEnter;

                return protDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

    public class clTagInfoLog
    {
        public eNodeTyp typ = new eNodeTyp();
        public System.Guid id = new System.Guid();
        public string protDetail = "";

        public string tabLog = "";
        public string tabLogFields = "";

        public string tabLogHelp = "";
        public string tabLogSchemaHelpxy = "";


        public clTagInfoLog()
        {
            typ = eNodeTyp.non;
        }

        public enum eNodeTyp
        {
            IDKlient = 0,
            non = 10
        }
    }

}
