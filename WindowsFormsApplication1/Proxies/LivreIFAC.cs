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
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:WebsIFAC/LivreIFAC", ConfigurationName="WCF.Proxies.LivreIFAC")]
    public interface LivreIFAC
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectAll", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectAllResponse")]
        System.Collections.Generic.List<WebsBO.LivreBO> SelectAll(string Token);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectAll", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectAllResponse")]
        System.IAsyncResult BeginSelectAll(string Token, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.LivreBO> EndSelectAll(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectByInfo", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectByInfoResponse")]
        System.Collections.Generic.List<WebsBO.LivreBO> SelectByInfo(string Token, string pLivreInfo, int pBibliothequeId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectByInfo", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectByInfoResponse")]
        System.IAsyncResult BeginSelectByInfo(string Token, string pLivreInfo, int pBibliothequeId, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.LivreBO> EndSelectByInfo(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectByBibliotheque", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectByBibliothequeResponse")]
        System.Collections.Generic.List<WebsBO.LivreBO> SelectByBibliotheque(string Token, WebsBO.BibliothequeBO pBibliotheque);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectByBibliotheque", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectByBibliothequeResponse")]
        System.IAsyncResult BeginSelectByBibliotheque(string Token, WebsBO.BibliothequeBO pBibliotheque, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<WebsBO.LivreBO> EndSelectByBibliotheque(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectFicheLivreForClientByLivreId", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectFicheLivreForClientByLivreIdResponse")]
        WebsBO.FicheLivreBO SelectFicheLivreForClientByLivreId(string Token, int pClientId, int pLivreId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectFicheLivreForClientByLivreId", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/SelectFicheLivreForClientByLivreIdResponse")]
        System.IAsyncResult BeginSelectFicheLivreForClientByLivreId(string Token, int pClientId, int pLivreId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.FicheLivreBO EndSelectFicheLivreForClientByLivreId(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/InsertLivre", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/InsertLivreResponse")]
        WebsBO.LivreBO InsertLivre(string Token, WebsBO.LivreBO pObjLivre, int AdministrateurId);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:WebsIFAC/LivreIFAC/LivreIFAC/InsertLivre", ReplyAction="urn:WebsIFAC/LivreIFAC/LivreIFAC/InsertLivreResponse")]
        System.IAsyncResult BeginInsertLivre(string Token, WebsBO.LivreBO pObjLivre, int AdministrateurId, System.AsyncCallback callback, object asyncState);
        
        WebsBO.LivreBO EndInsertLivre(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface LivreIFACChannel : WCF.Proxies.LivreIFAC, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LivreIFACClient : System.ServiceModel.ClientBase<WCF.Proxies.LivreIFAC>, WCF.Proxies.LivreIFAC
    {
        
        public LivreIFACClient()
        {
        }
        
        public LivreIFACClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public LivreIFACClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public LivreIFACClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public LivreIFACClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Collections.Generic.List<WebsBO.LivreBO> SelectAll(string Token)
        {
            return base.Channel.SelectAll(Token);
        }
        
        public System.IAsyncResult BeginSelectAll(string Token, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectAll(Token, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.LivreBO> EndSelectAll(System.IAsyncResult result)
        {
            return base.Channel.EndSelectAll(result);
        }
        
        public System.Collections.Generic.List<WebsBO.LivreBO> SelectByInfo(string Token, string pLivreInfo, int pBibliothequeId)
        {
            return base.Channel.SelectByInfo(Token, pLivreInfo, pBibliothequeId);
        }
        
        public System.IAsyncResult BeginSelectByInfo(string Token, string pLivreInfo, int pBibliothequeId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectByInfo(Token, pLivreInfo, pBibliothequeId, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.LivreBO> EndSelectByInfo(System.IAsyncResult result)
        {
            return base.Channel.EndSelectByInfo(result);
        }
        
        public System.Collections.Generic.List<WebsBO.LivreBO> SelectByBibliotheque(string Token, WebsBO.BibliothequeBO pBibliotheque)
        {
            return base.Channel.SelectByBibliotheque(Token, pBibliotheque);
        }
        
        public System.IAsyncResult BeginSelectByBibliotheque(string Token, WebsBO.BibliothequeBO pBibliotheque, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectByBibliotheque(Token, pBibliotheque, callback, asyncState);
        }
        
        public System.Collections.Generic.List<WebsBO.LivreBO> EndSelectByBibliotheque(System.IAsyncResult result)
        {
            return base.Channel.EndSelectByBibliotheque(result);
        }
        
        public WebsBO.FicheLivreBO SelectFicheLivreForClientByLivreId(string Token, int pClientId, int pLivreId)
        {
            return base.Channel.SelectFicheLivreForClientByLivreId(Token, pClientId, pLivreId);
        }
        
        public System.IAsyncResult BeginSelectFicheLivreForClientByLivreId(string Token, int pClientId, int pLivreId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginSelectFicheLivreForClientByLivreId(Token, pClientId, pLivreId, callback, asyncState);
        }
        
        public WebsBO.FicheLivreBO EndSelectFicheLivreForClientByLivreId(System.IAsyncResult result)
        {
            return base.Channel.EndSelectFicheLivreForClientByLivreId(result);
        }
        
        public WebsBO.LivreBO InsertLivre(string Token, WebsBO.LivreBO pObjLivre, int AdministrateurId)
        {
            return base.Channel.InsertLivre(Token, pObjLivre, AdministrateurId);
        }
        
        public System.IAsyncResult BeginInsertLivre(string Token, WebsBO.LivreBO pObjLivre, int AdministrateurId, System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginInsertLivre(Token, pObjLivre, AdministrateurId, callback, asyncState);
        }
        
        public WebsBO.LivreBO EndInsertLivre(System.IAsyncResult result)
        {
            return base.Channel.EndInsertLivre(result);
        }
    }
}
