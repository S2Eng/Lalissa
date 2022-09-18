using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace qs2.sitemap.queries
{


    public class KaplanMeier
    {

        public int MaxDifferenz;




        public KaplanMeier()
        {

        }

        public void calc(ref qs2.core.vb.dsKaplanMeier dsKM, int BeobachtungszeitraumInJahren, int Konfidenzband, double Alpha)
        {

            fillKolmogoroff(ref dsKM);
            fillHallWellnerKritVal(ref dsKM);
            calcRangListe(ref dsKM, BeobachtungszeitraumInJahren);
            calcEreignisListe(ref dsKM, Alpha);
            calcChartPointsZensiert(ref dsKM);

        }

        // Berechnung der Datenpunkte der Kaplan-Meier Kurve
        private void calcEreignisListe(ref qs2.core.vb.dsKaplanMeier dsKM, double Alpha)
        {
            int k = 0;
            int tk = 0;
            int Rang = 0;
            int Rk = dsKM.KMInput.Count();
            int dk = 0;
            double pk = 1;
            double S = 1;
            double C = 0;
            double Ct = 0;
            double K_ = 0;
            double S_ = 0;
            double _1KNt = 0;
            double KolmogoroffKritVal = 0;
            double HallWellnerKritVal = 0;
            double KolmogoroffMin = 0;
            double KolmogoroffMax = 0;
            double HallWellnerMin = 0;
            double HallWellnerMax = 0;
            int GesamtRk = dsKM.KMInput.Count();
            int cnt = 0;

            qs2.core.vb.dsKaplanMeier.KMResultRow rowKMRes0 = this.newRowKMResult(dsKM, false);
            qs2.core.vb.dsKaplanMeier.KMResultRow rowKMRes = this.newRowKMResult(dsKM, false);

            rowKMRes0.k = k;
            rowKMRes0.tk = tk;
            rowKMRes0.Rang = Rang;
            rowKMRes0.Rk = Rk;
            rowKMRes0.dk = dk;
            rowKMRes0.pk = pk;
            rowKMRes0.S = S;
            rowKMRes0.C = C;
            rowKMRes0.Ct = Ct;
            rowKMRes0.K_ = K_;
            rowKMRes0.S_ = S_;
            rowKMRes0._1KNt = _1KNt;
            rowKMRes0.KolmogoroffKritVal = KolmogoroffKritVal;
            rowKMRes0.HallWellnerKritVal = HallWellnerKritVal;
            rowKMRes0.KolmogoroffMin = KolmogoroffMin;
            rowKMRes0.KolmogoroffMax = KolmogoroffMax;
            rowKMRes0.HallWellnerMin = HallWellnerMin;
            rowKMRes0.HallWellnerMax = HallWellnerMax;

            var query = from item in dsKM.KMRangListe
                        where !item.IsVerweildauerNull()
                        group item by item.Verweildauer into groupedItems
                        let count = groupedItems.Count()
                        where count > 0
                        select new { tk = groupedItems.Key, dk = count };

            foreach (var item in query)
            {
                cnt += 1;

                tk = item.tk;

                Rang = getRang(ref dsKM, item.tk);

                Rk = getRk(ref dsKM, item.tk, Rk, cnt);

                dk = item.dk;

                pk = (1.0 - ((double)dk / (double)Rk));

                S = S * pk;

                Ct = getCt(ref dsKM, item.tk);

                C = GesamtRk * getCt(ref dsKM, item.tk);

                K_ = (1 / (1 + C));

                S_ = S / K_;

                _1KNt = 1 - K_;

                KolmogoroffKritVal = getKolmogoroffKritVal(ref dsKM, GesamtRk, Alpha);

                HallWellnerKritVal = getHallWellnerKritVal(ref dsKM, _1KNt, Alpha, GesamtRk);

                KolmogoroffMin = S - KolmogoroffKritVal;

                KolmogoroffMax = ((S + KolmogoroffKritVal) > 1) ? 1 : (S + KolmogoroffKritVal);

                HallWellnerMin = S - KolmogoroffKritVal * S_;

                HallWellnerMax = ((S + KolmogoroffKritVal * S_) > 1) ? 1 : (S + KolmogoroffKritVal * S_);

                rowKMRes = this.newRowKMResult(dsKM, false);


                if (cnt == 1)
                {
                    rowKMRes0.KolmogoroffMin = KolmogoroffMin;
                    rowKMRes0.KolmogoroffMax = KolmogoroffMax;
                    rowKMRes0.HallWellnerMin = HallWellnerMin;
                    rowKMRes0.HallWellnerMax = HallWellnerMax;

                    dsKM.KMResult.Rows.Add(rowKMRes0);
                }

                rowKMRes.k = cnt;
                rowKMRes.tk = tk;
                rowKMRes.Rang = Rang;
                rowKMRes.Rk = Rk;
                rowKMRes.dk = dk;
                rowKMRes.pk = pk;
                rowKMRes.S = S;
                rowKMRes.C = C;
                rowKMRes.Ct = Ct;
                rowKMRes.K_ = K_;
                rowKMRes.S_ = S_;
                rowKMRes._1KNt = _1KNt;
                rowKMRes.KolmogoroffKritVal = KolmogoroffKritVal;
                rowKMRes.HallWellnerKritVal = HallWellnerKritVal;
                rowKMRes.KolmogoroffMin = KolmogoroffMin;
                rowKMRes.KolmogoroffMax = KolmogoroffMax;
                rowKMRes.HallWellnerMin = HallWellnerMin;
                rowKMRes.HallWellnerMax = HallWellnerMax;

                dsKM.KMResult.Rows.Add(rowKMRes);
            }
        }

        // verbleibende Elemete unter Risiko ermitteln
        private int getRk(ref qs2.core.vb.dsKaplanMeier dsKM, int tk, int Rk, int cnt)
        {
            try
            {
                if (cnt == 1)
                {
                    var query = (from item in dsKM.KMRangListe
                                 where item.Differenz < tk
                                 select item).Count();
                    Rk = Rk - query;
                }
                else
                {
                    var query = (from item in dsKM.KMRangListe
                                 where item.Differenz >= tk
                                 select item).Count();
                    Rk = query;
                }

                return Rk;
            }
            catch (Exception e)
            {
                string xy = e.ToString();
                return -1;
            }
        }


        // aktuellen Rang für bestimmte Verweildauer ermitteln
        private int getRang(ref qs2.core.vb.dsKaplanMeier dsKM, int tk)
        {
            try
            {
                var query = (from item in dsKM.KMRangListe
                             where !item.IsVerweildauerNull() && item.Verweildauer == tk
                             select item.Rang).Max();
                return query;
            }
            catch (Exception e)
            {
                string xy = e.ToString();
                return -1;
            }
        }

        // Kosten der Zensierung ermitteln
        private double getCt(ref qs2.core.vb.dsKaplanMeier dsKM, int tk)
        {
            try
            {

                var query = (from item in dsKM.KMRangListe
                             where !item.IsVerweildauerNull() && item.Verweildauer <= tk
                             select item.C).Sum();
                return query;
            }
            catch (Exception e)
            {
                string xy = e.ToString();
                return -1;
            }

        }

        // aktuellen Rang für bestimmte Verweildauer ermitteln
        private double getKolmogoroffKritVal(ref qs2.core.vb.dsKaplanMeier dsKM, int GesamtRk, double Alpha)
        {

            try
            {
                if (GesamtRk > 50)
                {
                    if (Alpha == 0.1) return (1.22 / Math.Sqrt(GesamtRk));
                    if (Alpha == 0.05) return (1.36 / Math.Sqrt(GesamtRk));
                    if (Alpha == 0.01) return (1.63 / Math.Sqrt(GesamtRk));
                }
                else
                {
                    var query = (from item in dsKM.KMKolmogoroffKritValInterpol
                                 where item.Alpha == Alpha && item.N >= GesamtRk
                                 orderby item.Field<int>("N") ascending
                                 select item).Take(1);
                    return (double)query.ToList()[0].Value;
                }

                return 0.0;
            }
            catch (Exception e)
            {
                string xy = e.ToString();
                return 0.0;
            }

        }

        // Kritische Werte für Konfidenzbänder nach Kolmogoroff
        private void fillKolmogoroff(ref qs2.core.vb.dsKaplanMeier dsKM)
        {
            fillKolmogoroffKritVal(ref dsKM);
            fillKolmogoroffKritValInterpol(ref dsKM, 0.1);
            fillKolmogoroffKritValInterpol(ref dsKM, 0.05);
            fillKolmogoroffKritValInterpol(ref dsKM, 0.01);
        }

        // Kolmogoroff Ausgangstabelle
        private void fillKolmogoroffKritVal(ref qs2.core.vb.dsKaplanMeier dsKM)
        {
            qs2.core.vb.dsKaplanMeier.KMKolmogoroffKritValRow rowKMKritV;

            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 25;
            rowKMKritV.Alpha = 0.1;
            rowKMKritV.Value = 0.24;

            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 30;
            rowKMKritV.Alpha = 0.1;
            rowKMKritV.Value = 0.22;

            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 40;
            rowKMKritV.Alpha = 0.1;
            rowKMKritV.Value = 0.19;

            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 50;
            rowKMKritV.Alpha = 0.1;
            rowKMKritV.Value = 0.17;


            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 25;
            rowKMKritV.Alpha = 0.05;
            rowKMKritV.Value = 0.27;

            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 30;
            rowKMKritV.Alpha = 0.05;
            rowKMKritV.Value = 0.24;

            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 40;
            rowKMKritV.Alpha = 0.05;
            rowKMKritV.Value = 0.21;

            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 50;
            rowKMKritV.Alpha = 0.05;
            rowKMKritV.Value = 0.19;


            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 25;
            rowKMKritV.Alpha = 0.01;
            rowKMKritV.Value = 0.32;

            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 30;
            rowKMKritV.Alpha = 0.01;
            rowKMKritV.Value = 0.29;

            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 40;
            rowKMKritV.Alpha = 0.01;
            rowKMKritV.Value = 0.25;

            rowKMKritV = this.newRowKMKolmogoroffKritVal(dsKM);
            rowKMKritV.N = 50;
            rowKMKritV.Alpha = 0.01;
            rowKMKritV.Value = 0.23;
        }

        // HallWellner Ausgangstabelle
        private void fillHallWellnerKritVal(ref qs2.core.vb.dsKaplanMeier dsKM)
        {
            qs2.core.vb.dsKaplanMeier.KMHallWellnerKritValRow rowKMHWKritV;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.01;
            rowKMHWKritV._1KNt = 0.25;
            rowKMHWKritV.Value = 1.256;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.01;
            rowKMHWKritV._1KNt = 0.4;
            rowKMHWKritV.Value = 1.47;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.01;
            rowKMHWKritV._1KNt = 0.5;
            rowKMHWKritV.Value = 1.552;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.01;
            rowKMHWKritV._1KNt = 0.6;
            rowKMHWKritV.Value = 1.6;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.01;
            rowKMHWKritV._1KNt = 0.75;
            rowKMHWKritV.Value = 1.626;


            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.05;
            rowKMHWKritV._1KNt = 0.25;
            rowKMHWKritV.Value = 1.014;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.05;
            rowKMHWKritV._1KNt = 0.4;
            rowKMHWKritV.Value = 1.198;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.05;
            rowKMHWKritV._1KNt = 0.5;
            rowKMHWKritV.Value = 1.273;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.05;
            rowKMHWKritV._1KNt = 0.6;
            rowKMHWKritV.Value = 1.321;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.05;
            rowKMHWKritV._1KNt = 0.75;
            rowKMHWKritV.Value = 1.354;


            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.1;
            rowKMHWKritV._1KNt = 0.25;
            rowKMHWKritV.Value = 0.894;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.1;
            rowKMHWKritV._1KNt = 0.4;
            rowKMHWKritV.Value = 1.062;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.1;
            rowKMHWKritV._1KNt = 0.5;
            rowKMHWKritV.Value = 1.133;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.1;
            rowKMHWKritV._1KNt = 0.6;
            rowKMHWKritV.Value = 1.181;

            rowKMHWKritV = this.newRowKMHallWellnerKritVal(dsKM);
            rowKMHWKritV.Alpha = 0.1;
            rowKMHWKritV._1KNt = 0.75;
            rowKMHWKritV.Value = 1.217;
        }

        // Kritische Werte für Konfidenzbänder nach Hall-Wellner
        private double getHallWellnerKritVal(ref qs2.core.vb.dsKaplanMeier dsKM, double _1KNt, double Alpha, int GesamtRk)
        {
            return (getHallWellnerKritValInterpol(ref dsKM, _1KNt, Alpha) / Math.Sqrt(GesamtRk));
        }

        // Kritische Werte für Konfidenzbänder nach Hall-Wellner (interpoliert)
        private double getHallWellnerKritValInterpol(ref qs2.core.vb.dsKaplanMeier dsKM, double _1KNt, double Alpha)
        {

            double _1KNt_min = 0.25;
            double _1KNt_max = 0.75;
            double x0, x1, y0, y1, y_res;

            try
            {

                if (_1KNt < _1KNt_min) _1KNt = _1KNt_min;
                if (_1KNt > _1KNt_max) _1KNt = _1KNt_max;

                var query0 = (from item in dsKM.KMHallWellnerKritVal
                              where item.Alpha == Alpha && item._1KNt <= _1KNt
                              orderby item.Field<double>("_1KNt") descending
                              select item).Take(1);
                x0 = query0.ToList()[0]._1KNt;
                y0 = query0.ToList()[0].Value;


                var query1 = (from item in dsKM.KMHallWellnerKritVal
                              where item.Alpha == Alpha && item._1KNt >= _1KNt
                              orderby item.Field<double>("_1KNt") ascending
                              select item).Take(1);
                x1 = query1.ToList()[0]._1KNt;
                y1 = query1.ToList()[0].Value;

                if (x0 == x1)
                {
                    y_res = y0;
                }
                else
                {
                    y_res = y0 + (((y1 - y0) / (x1 - x0)) * (_1KNt - x0));

                }

                return y_res;
            }
            catch (Exception e)
            {
                string xy = e.ToString();
                return -1;
            }

        }

        // Kritische Werte für Konfidenzbänder nach Kolmogoroff
        private void fillKolmogoroffKritValInterpol(ref qs2.core.vb.dsKaplanMeier dsKM, double Alpha)
        {

            qs2.core.vb.dsKaplanMeier.KMKolmogoroffKritValInterpolRow rowKMKritVI;
            int min = 25;
            int max = 50;
            int x0, x1;
            double y0, y1, y_res;

            try
            {

                for (int i = min; i <= max; i++)
                {
                    var query0 = (from item in dsKM.KMKolmogoroffKritVal
                                  where item.Alpha == Alpha && item.N <= i
                                  orderby item.Field<int>("N") descending
                                  select item).Take(1);
                    x0 = query0.ToList()[0].N;
                    y0 = query0.ToList()[0].Value;


                    var query1 = (from item in dsKM.KMKolmogoroffKritVal
                                  where item.Alpha == Alpha && item.N >= i
                                  orderby item.Field<int>("N") ascending
                                  select item).Take(1);
                    x1 = query1.ToList()[0].N;
                    y1 = query1.ToList()[0].Value;

                    if (x0 == x1)
                    {
                        rowKMKritVI = this.newRowKMKolmogoroffKritValInterpol(dsKM);
                        rowKMKritVI.N = x0;
                        rowKMKritVI.Alpha = Alpha;
                        rowKMKritVI.Value = y0;
                    }
                    else
                    {
                        y_res = y0 + (((y1 - y0) / (x1 - x0)) * (i - x0));

                        rowKMKritVI = this.newRowKMKolmogoroffKritValInterpol(dsKM);
                        rowKMKritVI.N = i;
                        rowKMKritVI.Alpha = Alpha;
                        rowKMKritVI.Value = y_res;
                    }
                }


            }
            catch (Exception e)
            {
                throw new Exception("KaplanMeier.fillKolmogoroffKritValInterpol:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + e.ToString());
            }
        }

        // Zensierte Datenpunkte berechnen
        public void calcChartPointsZensiert(ref qs2.core.vb.dsKaplanMeier dsKM)
        {

            qs2.core.vb.dsKaplanMeier.KMChartZensiertRow rowKMCZ;

            var query = from item in dsKM.KMRangListe
                        where item.ZensiertJN == true
                        orderby item.Field<int>("Differenz") ascending
                        select item;

            foreach (var element in query)
            {

                var query1 = (from item in dsKM.KMResult
                              where item.tk <= element.Differenz
                              orderby item.Field<int>("tk") descending
                              select item).Take(1);
                if (query1.ToList().Count > 0)
                {
                    rowKMCZ = this.newRowKMChartZensiert(dsKM);
                    rowKMCZ.S = query1.ToList()[0].S;
                    rowKMCZ.Differenz = element.Differenz;
                }


            }

        }

        // berechnen der Rangliste
        private void calcRangListe(ref qs2.core.vb.dsKaplanMeier dsKM, int BeobachtungszeitraumInJahren)
        {
            try
            {
                int cnt = 0;
                int Rk = dsKM.KMInput.Count;
                qs2.core.vb.dsKaplanMeier.KMRangListeRow rowKMRang;

                if (!dsKM.KMInput.Columns.Contains("Differenz"))
                {
                    dsKM.KMInput.Columns.Add("Differenz", typeof(int));
                }

                foreach (qs2.core.vb.dsKaplanMeier.KMInputRow r in dsKM.KMInput.Rows)
                {
                    if (!r.IsFUPDtNull() && !r.IsSurgDtStartNull())
                    {
                        r["Differenz"] = r.FUPDt.Subtract(r.SurgDtStart).Days;
                    }
                    else
                    {
                        r["Differenz"] = 0;
                    }
                }

                var query = from c in dsKM.KMInput.AsEnumerable()
                            orderby c.Field<int>("Differenz") ascending
                            select c;
                qs2.core.vb.dsKaplanMeier.KMInputRow[] rows = query.ToArray();


                foreach (qs2.core.vb.dsKaplanMeier.KMInputRow r in rows)
                {

                    bool dontTake = false;
                    if ((Rk - cnt) > 0)
                    {
                        cnt += 1;

                        rowKMRang = this.newRowKMRangListe(dsKM, false);

                        rowKMRang.ZensiertJN = (r.FUPEreignis == 7) ? true : false;
                        rowKMRang.RecID = r.StayRecID;

                        if (!r.IsSurgDtStartNull())
                        {
                            rowKMRang.Inkorporation = r.SurgDtStart;
                        }
                        else
                        {
                            rowKMRang.Inkorporation = DateTime.Now.Date;
                            dontTake = true;
                        }
                        if (!r.IsFUPDtNull())
                        {
                            rowKMRang.LetzteKontrolle = r.FUPDt;
                        }
                        else
                        {
                            rowKMRang.LetzteKontrolle = DateTime.Now.Date;
                        }

                        if (!r.IsFUPDtNull())
                        {
                            if (rowKMRang.ZensiertJN) rowKMRang.SetVerlustdatumNull(); else rowKMRang.Verlustdatum = r.FUPDt;
                        }
                        else
                        {
                            rowKMRang.SetVerlustdatumNull();
                            dontTake = true;
                        }

                        if (!r.IsSurgDtStartNull() && !r.IsFUPDtNull())
                        {
                            rowKMRang.Differenz = r.FUPDt.Subtract(r.SurgDtStart).Days;
                        }
                        else
                        {
                            rowKMRang.Differenz = 0;
                            dontTake = true;
                        }


                        if (rowKMRang.ZensiertJN)
                        {
                            rowKMRang.SetVerweildauerNull();
                        }

                        else
                        {
                            if (!r.IsFUPDtNull())
                            {
                                rowKMRang.Verweildauer = r.FUPDt.Subtract(r.SurgDtStart).Days;
                            }
                        }
                        
                        rowKMRang.Rang = cnt;

                        if (rowKMRang.ZensiertJN)
                        {
                            rowKMRang.C = (double)0.0;
                        }
                        else
                        {
                            if ((Rk - cnt) > 0)
                            {
                                rowKMRang.C = (double)1.0 / ((double)(Rk - cnt + 1) * (double)(Rk - cnt));
                            }
                            else
                            {
                                rowKMRang.C = (double)0.0;
                            }
                        }

                        if (!dontTake)
                        {
                            dsKM.KMRangListe.Rows.Add(rowKMRang);
                        }
                    }

                }

                if (dsKM.KMRangListe.Rows.Count == 0)
                {
                    this.MaxDifferenz = 0;
                }
                else
                {
                    var maxDifferenz = (from item in dsKM.KMRangListe
                                        select item.Differenz).Max();
                    this.MaxDifferenz = maxDifferenz;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("KaplanMeier.calcRangListe:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public qs2.core.vb.dsKaplanMeier.KMInputRow newRowKMInput(qs2.core.vb.dsKaplanMeier ds)
        {
            qs2.core.vb.dsKaplanMeier.KMInputRow rNew = (qs2.core.vb.dsKaplanMeier.KMInputRow)ds.KMInput.NewRow();
            rNew.PatExtID = "";
            rNew.PatFirstname = "";
            rNew.PatLastname = "";
            rNew.SetPatDOBNull();
            rNew.SetStayIDNull();
            rNew.StayRecID = -999;
            rNew.StayMedRecNum = "";
            rNew.SetSurgDtStartNull();
            rNew.SetFUPDtNull();
            rNew.SetFUPEreignisNull();

            ds.KMInput.Rows.Add(rNew);
            return rNew;
        }

        public qs2.core.vb.dsKaplanMeier.KMRangListeRow newRowKMRangListe(qs2.core.vb.dsKaplanMeier ds, bool addToDs)
        {
            qs2.core.vb.dsKaplanMeier.KMRangListeRow rNew = (qs2.core.vb.dsKaplanMeier.KMRangListeRow)ds.KMRangListe.NewRow();
            rNew.RecID = -1;
            rNew.SetInkorporationNull();
            rNew.SetLetzteKontrolleNull();
            rNew.SetVerlustdatumNull();
            rNew.Differenz = 0;
            rNew.SetVerweildauerNull();
            rNew.ZensiertJN = false;
            rNew.Rang = -1;
            rNew.C = 0;

            if (addToDs)
                ds.KMRangListe.Rows.Add(rNew);

            return rNew;
        }



        public qs2.core.vb.dsKaplanMeier.KMResultRow newRowKMResult(qs2.core.vb.dsKaplanMeier ds, bool addToDs)
        {
            qs2.core.vb.dsKaplanMeier.KMResultRow rNew = (qs2.core.vb.dsKaplanMeier.KMResultRow)ds.KMResult.NewRow();
            rNew.k = 0;
            rNew.tk = 0;
            rNew.Rang = 0;
            rNew.Rk = 0;
            rNew.dk = 0;
            rNew.pk = 0;
            rNew.S = 0;
            rNew.C = 0;
            rNew.Ct = 0;
            rNew.K_ = 0;
            rNew.S_ = 0;
            rNew._1KNt = 0;
            rNew.KolmogoroffKritVal = 0;
            rNew.HallWellnerKritVal = 0;
            rNew.KolmogoroffMin = 0;
            rNew.KolmogoroffMax = 0;
            rNew.HallWellnerMin = 0;
            rNew.HallWellnerMax = 0;

            if (addToDs)
                ds.KMResult.Rows.Add(rNew);

            return rNew;
        }

        public qs2.core.vb.dsKaplanMeier.KMKolmogoroffKritValRow newRowKMKolmogoroffKritVal(qs2.core.vb.dsKaplanMeier ds)
        {
            qs2.core.vb.dsKaplanMeier.KMKolmogoroffKritValRow rNew = (qs2.core.vb.dsKaplanMeier.KMKolmogoroffKritValRow)ds.KMKolmogoroffKritVal.NewRow();
            rNew.N = 0;
            rNew.Alpha = 0;
            rNew.Value = 0;

            ds.KMKolmogoroffKritVal.Rows.Add(rNew);
            return rNew;
        }

        public qs2.core.vb.dsKaplanMeier.KMKolmogoroffKritValInterpolRow newRowKMKolmogoroffKritValInterpol(qs2.core.vb.dsKaplanMeier ds)
        {
            qs2.core.vb.dsKaplanMeier.KMKolmogoroffKritValInterpolRow rNew = (qs2.core.vb.dsKaplanMeier.KMKolmogoroffKritValInterpolRow)ds.KMKolmogoroffKritValInterpol.NewRow();
            rNew.N = 0;
            rNew.Alpha = 0;
            rNew.Value = 0;

            ds.KMKolmogoroffKritValInterpol.Rows.Add(rNew);
            return rNew;
        }

        public qs2.core.vb.dsKaplanMeier.KMHallWellnerKritValRow newRowKMHallWellnerKritVal(qs2.core.vb.dsKaplanMeier ds)
        {
            qs2.core.vb.dsKaplanMeier.KMHallWellnerKritValRow rNew = (qs2.core.vb.dsKaplanMeier.KMHallWellnerKritValRow)ds.KMHallWellnerKritVal.NewRow();
            rNew.Alpha = 0;
            rNew._1KNt = 0;
            rNew.Value = 0;

            ds.KMHallWellnerKritVal.Rows.Add(rNew);
            return rNew;
        }

        public qs2.core.vb.dsKaplanMeier.KMChartZensiertRow newRowKMChartZensiert(qs2.core.vb.dsKaplanMeier ds)
        {
            qs2.core.vb.dsKaplanMeier.KMChartZensiertRow rNew = (qs2.core.vb.dsKaplanMeier.KMChartZensiertRow)ds.KMChartZensiert.NewRow();
            rNew.Differenz = 0;
            rNew.S = 0;

            ds.KMChartZensiert.Rows.Add(rNew);
            return rNew;

        }
    }
}
