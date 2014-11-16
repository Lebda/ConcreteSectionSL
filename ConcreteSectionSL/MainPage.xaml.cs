using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using XEP_EsaModelData.EmdData.Inputs;
using XEP_EsaModelData.EmdFiles.Interface;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace ConcreteSectionSL
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            _emdDocument = XEP_EmdReadWriteFactory.Instance().CreateEmdDocument();
            _emdDocumentXML = XEP_EmdReadWriteFactory.Instance().CreateEmdDocument();
            _dialog = new SaveFileDialog();
            _dialogEmd = new SaveFileDialog();
            _crossSectionEmdFile = XEP_EmdReadWriteFactory.Instance().CreateCrossSectionEmdFile();
            _reinfEmdFile = XEP_EmdReadWriteFactory.Instance().CreateReinforcementEmdFile();
            _matEmdFile = XEP_EmdReadWriteFactory.Instance().CreateMaterialsEmdFile();
            _barsSectionID = 0;
            try
            {
                _dialog.DefaultExt = ".xml";
                _dialog.Filter = "Text Files (*.xml)|*.xml";
                _dialog.FilterIndex = 1;
                _dialogEmd.DefaultExt = ".emd";
                _dialogEmd.Filter = "Text Files (*.emd)|*.emd";
                _dialogEmd.FilterIndex = 1;
            }
            catch (Exception ex)
            {
                //this.tblError.Text = "Error configuring SaveFileDialog: " + ex.Message;
            }
        }
        
        #region MEMBERS
        XEP_IEmdDocument _emdDocument;
        private SaveFileDialog _dialog;
        private SaveFileDialog _dialogEmd;
        XEP_IEmdDocument _emdDocumentXML;
        XEP_ICrossSectionEmdFile _crossSectionEmdFile;
        XEP_IReinforcementEmdFile _reinfEmdFile;
        XEP_IMaterialsEmdFile _matEmdFile;
        int _barsSectionID;
        #endregion
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            dialog.Multiselect = true;
            
            // Show the dialog box. 
            if (dialog.ShowDialog() == true)
            {
                foreach (FileInfo file in dialog.Files)
                {
                    using (Stream fileStream = file.OpenRead())
                    {
                        _emdDocument.Load(fileStream);
                    }
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_dialog.ShowDialog() == true)
                {
                    using (Stream stream = _dialog.OpenFile())
                    {
                        XDocument documentXml = new XDocument(
                            new XDeclaration("1.0", null, "yes"),
                            new XComment("Xml created from Emd file"));
                        documentXml.Add(_emdDocument.Root.CreateXElement());
                        documentXml.Save(stream);
                    }
                }
            }
            catch (Exception ex)
            { 
                throw;
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        { // load emd from xml
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            dialog.Multiselect = true;
            
            // Show the dialog box. 
            if (dialog.ShowDialog() == true)
            {
                foreach (FileInfo file in dialog.Files)
                {
                    using (Stream fileStream = file.OpenRead())
                    {
                        XDocument documentXml = XDocument.Load(fileStream);
                        _emdDocumentXML.Load(documentXml);
                    }
                }
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        { // save emd from xml
            try
            {
                if (_dialogEmd.ShowDialog() == true)
                {
                    using (Stream stream = _dialogEmd.OpenFile())
                    {
                        _emdDocumentXML.Save(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void TestLoadShapePoints(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            dialog.Multiselect = true;
            
            // Show the dialog box. 
            if (dialog.ShowDialog() == true)
            {
                foreach (FileInfo file in dialog.Files)
                {
                    using (Stream fileStream = file.OpenRead())
                    {
                        _crossSectionEmdFile.Load(fileStream);
                        OutPut.Text = String.Empty;
                        OutPut.Text += "Cross section points";
                        OutPut.Text += Environment.NewLine;
                        List<Point> points = _crossSectionEmdFile.GetShape();
                        foreach (var item in points)
                        {
                            OutPut.Text += item.ToString();
                            OutPut.Text += Environment.NewLine;
                        }
                        OutPut.Text += "Form code";
                        OutPut.Text += Environment.NewLine;
                        OutPut.Text += _crossSectionEmdFile.GetFormCode().ToString();
                    }
                }
            }
        }
        private void TestLoadBars(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            dialog.Multiselect = true;
            
            // Show the dialog box. 
            if (dialog.ShowDialog() == true)
            {
                foreach (FileInfo file in dialog.Files)
                {
                    using (Stream fileStream = file.OpenRead())
                    {
                        _reinfEmdFile.Load(fileStream);
                        OutPutReinf.Text = String.Empty;
                        OutPutReinf.Text += "Bars";
                        OutPutReinf.Text += Environment.NewLine;
                        List<XEP_IBarIO> bars = _reinfEmdFile.GetBars(_barsSectionID);
                        foreach (var item in bars)
                        {
                            OutPutReinf.Text += item.ToString();
                            OutPutReinf.Text += Environment.NewLine;
                        }
                    }
                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string dataValue = ((TextBox)sender).Text;
            double result;
            if (double.TryParse(dataValue, NumberStyles.Any, Thread.CurrentThread.CurrentCulture, out result))
            {
                _barsSectionID = (int)result;
            }
        }
        //
        private void TestLoadMaterialReinf(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Emd Files (*.emd)|*.emd";
                dialog.Multiselect = false;

                // Show the dialog box. 
                if (dialog.ShowDialog() == true)
                {
                    foreach (FileInfo file in dialog.Files)
                    {
                        using (Stream fileStream = file.OpenRead())
                        {
                            _matEmdFile.Load(fileStream);
                            OutPutMat.Text = String.Empty;
                            OutPutMat.Text += "Reinf material";
                            OutPutMat.Text += Environment.NewLine;
                            OutPutMat.Text += _matEmdFile.GetBaseMaterial(XEP_EmdNames.s_Value_eRsteel); ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}