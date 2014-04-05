﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18444
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF.Proxies
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:WebsIFAC/EmpruntIFAC", ConfigurationName="WCF.Proxies.EmpruntIFAC")]
    public interface EmpruntIFAC
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectAll", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectAllResponse")]
        System.Collections.Generic.List<WebsBO.EmpruntBO> SelectAll();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectAll", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectAllResponse")]
        System.IAsyncResult BeginSelectAll(System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.EmpruntBO> EndSelectAll(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntById", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntByIdResponse")]
        WebsBO.EmpruntBO SelectEmpruntById(int pId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntById", ReplyAction="urn:WebsIFAC/EmpruntIFAC/EmpruntIFAC/SelectEmpruntByIdResponse")]
        System.IAsyncResult BeginSelectEmpruntById(int pId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.EmpruntBO EndSelectEmpruntById(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface EmpruntIFACChannel : WCF.Proxies.EmpruntIFAC, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmpruntIFACClient : System.ServiceModel.ClientBase<WCF.Proxies.EmpruntIFAC>, WCF.Proxies.EmpruntIFAC
    {
        
        public EmpruntIFACClient()
        {
        }
        
        public EmpruntIFACClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public EmpruntIFACClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public EmpruntIFACClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public EmpruntIFACClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Collections.Generic.List<WebsBO.EmpruntBO> SelectAll()
        {
            return base.Channel.SelectAll();
        }
        
        public System.IAsyncResult BeginSelectAll(System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectAll(callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.EmpruntBO> EndSelectAll(System.IAsyncResult result)
        {
            return base.Channel.EndSelectAll(result);
        }
        
        public WebsBO.EmpruntBO SelectEmpruntById(int pId)
        {
            return base.Channel.SelectEmpruntById(pId);
        }
        
        public System.IAsyncResult BeginSelectEmpruntById(int pId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectEmpruntById(pId, callback, asyncState);
        }
        
        public WebsBO.EmpruntBO EndSelectEmpruntById(System.IAsyncResult result)
        {
            return base.Channel.EndSelectEmpruntById(result);
        }
    }
}
