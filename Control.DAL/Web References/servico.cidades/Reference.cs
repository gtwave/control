﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Control.DAL.servico.cidades {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="cidadesSoap", Namespace="http://tempuri.org/")]
    public partial class cidades : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RETORNA_ESTADOSOperationCompleted;
        
        private System.Threading.SendOrPostCallback RETORNA_CIDADES_ESTADOOperationCompleted;
        
        private System.Threading.SendOrPostCallback RETORNA_CIDADESOperationCompleted;
        
        private System.Threading.SendOrPostCallback RETORNA_CIDADES_FILTROOperationCompleted;
        
        private System.Threading.SendOrPostCallback RETORNA_CIDADE_ESPECIFICAOperationCompleted;
        
        private System.Threading.SendOrPostCallback RETORNA_ESTADO_ESPECIFICOOperationCompleted;
        
        private System.Threading.SendOrPostCallback RETORNA_CIDADE_CEPOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public cidades() {
            this.Url = global::Control.DAL.Properties.Settings.Default.Control_DAL_servico_cidades_cidades;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event RETORNA_ESTADOSCompletedEventHandler RETORNA_ESTADOSCompleted;
        
        /// <remarks/>
        public event RETORNA_CIDADES_ESTADOCompletedEventHandler RETORNA_CIDADES_ESTADOCompleted;
        
        /// <remarks/>
        public event RETORNA_CIDADESCompletedEventHandler RETORNA_CIDADESCompleted;
        
        /// <remarks/>
        public event RETORNA_CIDADES_FILTROCompletedEventHandler RETORNA_CIDADES_FILTROCompleted;
        
        /// <remarks/>
        public event RETORNA_CIDADE_ESPECIFICACompletedEventHandler RETORNA_CIDADE_ESPECIFICACompleted;
        
        /// <remarks/>
        public event RETORNA_ESTADO_ESPECIFICOCompletedEventHandler RETORNA_ESTADO_ESPECIFICOCompleted;
        
        /// <remarks/>
        public event RETORNA_CIDADE_CEPCompletedEventHandler RETORNA_CIDADE_CEPCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RETORNA_ESTADOS", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet RETORNA_ESTADOS() {
            object[] results = this.Invoke("RETORNA_ESTADOS", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void RETORNA_ESTADOSAsync() {
            this.RETORNA_ESTADOSAsync(null);
        }
        
        /// <remarks/>
        public void RETORNA_ESTADOSAsync(object userState) {
            if ((this.RETORNA_ESTADOSOperationCompleted == null)) {
                this.RETORNA_ESTADOSOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRETORNA_ESTADOSOperationCompleted);
            }
            this.InvokeAsync("RETORNA_ESTADOS", new object[0], this.RETORNA_ESTADOSOperationCompleted, userState);
        }
        
        private void OnRETORNA_ESTADOSOperationCompleted(object arg) {
            if ((this.RETORNA_ESTADOSCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RETORNA_ESTADOSCompleted(this, new RETORNA_ESTADOSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RETORNA_CIDADES_ESTADO", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet RETORNA_CIDADES_ESTADO(string ESTADO) {
            object[] results = this.Invoke("RETORNA_CIDADES_ESTADO", new object[] {
                        ESTADO});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void RETORNA_CIDADES_ESTADOAsync(string ESTADO) {
            this.RETORNA_CIDADES_ESTADOAsync(ESTADO, null);
        }
        
        /// <remarks/>
        public void RETORNA_CIDADES_ESTADOAsync(string ESTADO, object userState) {
            if ((this.RETORNA_CIDADES_ESTADOOperationCompleted == null)) {
                this.RETORNA_CIDADES_ESTADOOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRETORNA_CIDADES_ESTADOOperationCompleted);
            }
            this.InvokeAsync("RETORNA_CIDADES_ESTADO", new object[] {
                        ESTADO}, this.RETORNA_CIDADES_ESTADOOperationCompleted, userState);
        }
        
        private void OnRETORNA_CIDADES_ESTADOOperationCompleted(object arg) {
            if ((this.RETORNA_CIDADES_ESTADOCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RETORNA_CIDADES_ESTADOCompleted(this, new RETORNA_CIDADES_ESTADOCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RETORNA_CIDADES", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet RETORNA_CIDADES() {
            object[] results = this.Invoke("RETORNA_CIDADES", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void RETORNA_CIDADESAsync() {
            this.RETORNA_CIDADESAsync(null);
        }
        
        /// <remarks/>
        public void RETORNA_CIDADESAsync(object userState) {
            if ((this.RETORNA_CIDADESOperationCompleted == null)) {
                this.RETORNA_CIDADESOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRETORNA_CIDADESOperationCompleted);
            }
            this.InvokeAsync("RETORNA_CIDADES", new object[0], this.RETORNA_CIDADESOperationCompleted, userState);
        }
        
        private void OnRETORNA_CIDADESOperationCompleted(object arg) {
            if ((this.RETORNA_CIDADESCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RETORNA_CIDADESCompleted(this, new RETORNA_CIDADESCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RETORNA_CIDADES_FILTRO", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet RETORNA_CIDADES_FILTRO(string ESTADO, string NOME) {
            object[] results = this.Invoke("RETORNA_CIDADES_FILTRO", new object[] {
                        ESTADO,
                        NOME});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void RETORNA_CIDADES_FILTROAsync(string ESTADO, string NOME) {
            this.RETORNA_CIDADES_FILTROAsync(ESTADO, NOME, null);
        }
        
        /// <remarks/>
        public void RETORNA_CIDADES_FILTROAsync(string ESTADO, string NOME, object userState) {
            if ((this.RETORNA_CIDADES_FILTROOperationCompleted == null)) {
                this.RETORNA_CIDADES_FILTROOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRETORNA_CIDADES_FILTROOperationCompleted);
            }
            this.InvokeAsync("RETORNA_CIDADES_FILTRO", new object[] {
                        ESTADO,
                        NOME}, this.RETORNA_CIDADES_FILTROOperationCompleted, userState);
        }
        
        private void OnRETORNA_CIDADES_FILTROOperationCompleted(object arg) {
            if ((this.RETORNA_CIDADES_FILTROCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RETORNA_CIDADES_FILTROCompleted(this, new RETORNA_CIDADES_FILTROCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RETORNA_CIDADE_ESPECIFICA", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet RETORNA_CIDADE_ESPECIFICA(int COD) {
            object[] results = this.Invoke("RETORNA_CIDADE_ESPECIFICA", new object[] {
                        COD});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void RETORNA_CIDADE_ESPECIFICAAsync(int COD) {
            this.RETORNA_CIDADE_ESPECIFICAAsync(COD, null);
        }
        
        /// <remarks/>
        public void RETORNA_CIDADE_ESPECIFICAAsync(int COD, object userState) {
            if ((this.RETORNA_CIDADE_ESPECIFICAOperationCompleted == null)) {
                this.RETORNA_CIDADE_ESPECIFICAOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRETORNA_CIDADE_ESPECIFICAOperationCompleted);
            }
            this.InvokeAsync("RETORNA_CIDADE_ESPECIFICA", new object[] {
                        COD}, this.RETORNA_CIDADE_ESPECIFICAOperationCompleted, userState);
        }
        
        private void OnRETORNA_CIDADE_ESPECIFICAOperationCompleted(object arg) {
            if ((this.RETORNA_CIDADE_ESPECIFICACompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RETORNA_CIDADE_ESPECIFICACompleted(this, new RETORNA_CIDADE_ESPECIFICACompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RETORNA_ESTADO_ESPECIFICO", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RETORNA_ESTADO_ESPECIFICO(int COD) {
            object[] results = this.Invoke("RETORNA_ESTADO_ESPECIFICO", new object[] {
                        COD});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RETORNA_ESTADO_ESPECIFICOAsync(int COD) {
            this.RETORNA_ESTADO_ESPECIFICOAsync(COD, null);
        }
        
        /// <remarks/>
        public void RETORNA_ESTADO_ESPECIFICOAsync(int COD, object userState) {
            if ((this.RETORNA_ESTADO_ESPECIFICOOperationCompleted == null)) {
                this.RETORNA_ESTADO_ESPECIFICOOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRETORNA_ESTADO_ESPECIFICOOperationCompleted);
            }
            this.InvokeAsync("RETORNA_ESTADO_ESPECIFICO", new object[] {
                        COD}, this.RETORNA_ESTADO_ESPECIFICOOperationCompleted, userState);
        }
        
        private void OnRETORNA_ESTADO_ESPECIFICOOperationCompleted(object arg) {
            if ((this.RETORNA_ESTADO_ESPECIFICOCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RETORNA_ESTADO_ESPECIFICOCompleted(this, new RETORNA_ESTADO_ESPECIFICOCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RETORNA_CIDADE_CEP", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet RETORNA_CIDADE_CEP(string CEP) {
            object[] results = this.Invoke("RETORNA_CIDADE_CEP", new object[] {
                        CEP});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void RETORNA_CIDADE_CEPAsync(string CEP) {
            this.RETORNA_CIDADE_CEPAsync(CEP, null);
        }
        
        /// <remarks/>
        public void RETORNA_CIDADE_CEPAsync(string CEP, object userState) {
            if ((this.RETORNA_CIDADE_CEPOperationCompleted == null)) {
                this.RETORNA_CIDADE_CEPOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRETORNA_CIDADE_CEPOperationCompleted);
            }
            this.InvokeAsync("RETORNA_CIDADE_CEP", new object[] {
                        CEP}, this.RETORNA_CIDADE_CEPOperationCompleted, userState);
        }
        
        private void OnRETORNA_CIDADE_CEPOperationCompleted(object arg) {
            if ((this.RETORNA_CIDADE_CEPCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RETORNA_CIDADE_CEPCompleted(this, new RETORNA_CIDADE_CEPCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RETORNA_ESTADOSCompletedEventHandler(object sender, RETORNA_ESTADOSCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RETORNA_ESTADOSCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RETORNA_ESTADOSCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RETORNA_CIDADES_ESTADOCompletedEventHandler(object sender, RETORNA_CIDADES_ESTADOCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RETORNA_CIDADES_ESTADOCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RETORNA_CIDADES_ESTADOCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RETORNA_CIDADESCompletedEventHandler(object sender, RETORNA_CIDADESCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RETORNA_CIDADESCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RETORNA_CIDADESCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RETORNA_CIDADES_FILTROCompletedEventHandler(object sender, RETORNA_CIDADES_FILTROCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RETORNA_CIDADES_FILTROCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RETORNA_CIDADES_FILTROCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RETORNA_CIDADE_ESPECIFICACompletedEventHandler(object sender, RETORNA_CIDADE_ESPECIFICACompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RETORNA_CIDADE_ESPECIFICACompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RETORNA_CIDADE_ESPECIFICACompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RETORNA_ESTADO_ESPECIFICOCompletedEventHandler(object sender, RETORNA_ESTADO_ESPECIFICOCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RETORNA_ESTADO_ESPECIFICOCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RETORNA_ESTADO_ESPECIFICOCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void RETORNA_CIDADE_CEPCompletedEventHandler(object sender, RETORNA_CIDADE_CEPCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RETORNA_CIDADE_CEPCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RETORNA_CIDADE_CEPCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591