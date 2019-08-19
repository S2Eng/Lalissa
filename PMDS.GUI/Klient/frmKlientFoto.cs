using PMDS.BusinessLogic;
using PMDS.DB;
using PMDS.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.Klient
{

    public partial class frmKlientFoto : Form
    {

        public Guid _IDKlient;
        public PMDSBusiness PMDSBusiness1 = new PMDSBusiness();

        public bool _isBewerberJN = false;
        public bool _Datenschutz = false;






        public frmKlientFoto()
        {
            InitializeComponent();
        }


        private void frmKlientFoto_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }


        public void initControl(Guid IDKlient, bool isBewerberJN)
        {
            try
            {
                _IDKlient = IDKlient;
                _isBewerberJN = isBewerberJN;

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    if (!this.PMDSBusiness1.checkPatientExists(_IDKlient, db))
                    {
                        this.panelButtonsBild.Visible = false;
                        this.btnMagnify.Visible = false;
                    }
                    else
                    {
                        this.panelButtonsBild.Visible = true;
                        this.btnMagnify.Visible = true;

                        var rKlient = (from p in db.Patient
                                       where p.ID == _IDKlient
                                       select new
                                       {
                                           p.ID,
                                           p.Foto,
                                           p.Datenschutz
                                       }).First();

                        this._IDKlient = rKlient.ID;
                        this._Datenschutz = rKlient.Datenschutz;
                        this.foto3.Image = rKlient.Foto;

                        if (PMDS.Global.historie.HistorieOn && !ENV.HasRight(UserRights.HistorischeDatenÄndern))
                        {
                            this.panelButtonsBild.Visible = false;
                            this.btnMagnify.Visible = false;
                        }
                        else
                        {
                            if (ENV.HasRight(UserRights.KlientenAktStammdatenAendern))
                            {
                                this.panelButtonsBild.Visible = true;
                                this.btnMagnify.Visible = true;
                            }
                            else
                            {
                                this.panelButtonsBild.Visible = false;
                                this.btnMagnify.Visible = false;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmKlientFoto.initControl: " + ex.ToString());
            }
        }


        private void btnPicClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.foto3.Image != null)
                {
                    if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sind Sie sicher, dass Sie das Bild löschen wollen?", "PMDS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                        {
                            PMDS.db.Entities.Patient rPatient = PMDSBusiness1.getPatient2(this._IDKlient, db);
                            rPatient.Foto = null;
                            db.SaveChanges();

                            foto3.Image = null;
                   
                            PMDSBusiness1.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient: '") + 
                                                        rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' -> Bild wurde gelöscht!"), 
                                                        this._isBewerberJN, this._IDKlient, PflegeEintragTyp.Klient);
                        }
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Änderung wurde gespeichert", "Speichern", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnPicLoad_Click(object sender, EventArgs e)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Patient rPatient = PMDSBusiness1.getPatient2(this._IDKlient, db);

                    if (_Datenschutz == false)
                    {
                        openFileDialog1.FileName = "";
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            rPatient.Foto = File.ReadAllBytes(openFileDialog1.FileName);        
                            db.SaveChanges();
                            foto3.Image = rPatient.Foto;

                            PMDSBusiness1.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient: '") + rPatient.Nachname.Trim() + " " +
                                                    rPatient.Vorname.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' -> Bild wurde geändert!"), this._isBewerberJN, this._IDKlient, PflegeEintragTyp.Klient);

                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Änderung wurde gespeichert", "Speichern", MessageBoxButtons.OK);


                            //Directory.SetCurrentDirectory(Directory.GetParent(openFileDialog1.FileName).FullName.ToString());
                            //FileStream myStream = new FileStream(openFileDialog1.FileName, FileMode.Open);
                            //byte[] bFoto = File.ReadAllBytes(openFileDialog1.FileName);
                            //BUtil.ImageToArray(Image.FromStream(myStream));
                        }
                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datenschutz ist aktiviert. Sie dürfen kein Foto hinzufügen.", "Hinweis", MessageBoxButtons.OK);

                    }
                }


            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void btnPicSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            if (this.foto3.Image != null)
            {
                saveFileDialog1.Filter = "jpg Dateien (*.jpg)|*.jpg";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    PermissionSet permissionSet = new PermissionSet(PermissionState.None);
                    FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, saveFileDialog1.FileName);
                    permissionSet.AddPermission(writePermission);
                    if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
                    {
                        using (MemoryStream s = new MemoryStream((Byte[])foto3.Image))
                        {
                            new Bitmap((Image)Image.FromStream(s)).Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                        }
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Änderung wurde gespeichert", "Speichern", MessageBoxButtons.OK);
                    }               
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben kein Recht, die Datei hier zu speichern", "Speichern", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnPicRotateRight_Click(object sender, EventArgs e)
        {
            if (foto3.Image != null)
            {
                using (var s = new MemoryStream((Byte[])foto3.Image))
                {
                    var b = new Bitmap((Image)Image.FromStream(s));
                    b.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        PMDS.db.Entities.Patient rPatient = PMDSBusiness1.getPatient2(this._IDKlient, db);
                        rPatient.Foto = BUtil.ImageToArray(b);
                        db.SaveChanges();
                        this.foto3.Image = rPatient.Foto;
                    }
                }
            }
        }

        private void btnMagnify_Click(object sender, EventArgs e)
        {
            try
            {
                PMDS.Global.UI.frmPictureViewer frm = new PMDS.Global.UI.frmPictureViewer();
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Patient rPatient = PMDSBusiness1.getPatient2(this._IDKlient, db);
                    frm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bild von ") + rPatient.Nachname + " " + rPatient.Vorname + QS2.Desktop.ControlManagment.ControlManagment.getRes(", geb. am ") + string.Format("{0:d}", rPatient.Geburtsdatum);
                    if (rPatient.Foto != null)
                    {
                        MemoryStream ms = new MemoryStream(rPatient.Foto);
                        Image returnImage = Image.FromStream(ms);
                        frm.pictureBox1.Image = returnImage;
                        frm.Show(this);
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
    }
}
