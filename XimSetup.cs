using System;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
class XimSetup : Form {
 TextBox path; Button install; ProgressBar bar; Label status;
 XimSetup(){
  Text="XIM AI Setup"; Width=620; Height=300; StartPosition=FormStartPosition.CenterScreen; BackColor=Color.FromArgb(10,10,12); ForeColor=Color.White;
  var t=new Label(){Text="XIM AI",Left=35,Top=25,Width=500,Height=40,Font=new Font("Segoe UI",22,FontStyle.Bold)};
  var s=new Label(){Text="Local AI workspace installer",Left=37,Top=68,Width=500,ForeColor=Color.Silver};
  path=new TextBox(){Left=37,Top=110,Width=520,Text=Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\XIM.Matrix"};
  install=new Button(){Text="Install XIM",Left=37,Top=150,Width=130,Height=38,FlatStyle=FlatStyle.Flat};
  bar=new ProgressBar(){Left=37,Top=200,Width=520,Height=10}; status=new Label(){Text="Ready.",Left=37,Top=225,Width=520};
  Controls.AddRange(new Control[]{t,s,path,install,bar,status}); install.Click+=async(a,b)=>await DoInstall();
 }
 async System.Threading.Tasks.Task DoInstall(){
  install.Enabled=false; string d=path.Text; Directory.CreateDirectory(d); string z=Path.Combine(d,"XIM-Payload.zip");
  try{
   status.Text="Downloading current XIM..."; bar.Value=15;
   using(var w=new WebClient()){await w.DownloadFileTaskAsync(new Uri("https://github.com/romeomalcgh/XIM-AI/releases/latest/download/XIM-Payload.zip"),z);}
   status.Text="Extracting XIM..."; bar.Value=70; ZipFile.ExtractToDirectory(z,d); File.Delete(z);
   bar.Value=100; status.Text="Installation complete."; string e=Path.Combine(d,"XimAdmin.exe"); if(File.Exists(e)) Process.Start(e); Close();
  }catch(Exception ex){install.Enabled=true;status.Text="Install failed: "+ex.Message;}
 }
 [STAThread] static void Main(){Application.EnableVisualStyles();Application.Run(new XimSetup());}
}