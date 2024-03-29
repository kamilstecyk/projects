﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryProject.CurrencyExchangeServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CurrencyExchangeServiceReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ShowExchangeRate", ReplyAction="http://tempuri.org/IService1/ShowExchangeRateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IService1/ShowExchangeRateFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        double ShowExchangeRate(string currencySymbol);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ShowExchangeRate", ReplyAction="http://tempuri.org/IService1/ShowExchangeRateResponse")]
        System.Threading.Tasks.Task<double> ShowExchangeRateAsync(string currencySymbol);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SellValue", ReplyAction="http://tempuri.org/IService1/SellValueResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IService1/SellValueFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        double SellValue(string currencySymbol, double howManyCurrency);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SellValue", ReplyAction="http://tempuri.org/IService1/SellValueResponse")]
        System.Threading.Tasks.Task<double> SellValueAsync(string currencySymbol, double howManyCurrency);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getAllAvailableCurrencies", ReplyAction="http://tempuri.org/IService1/getAllAvailableCurrenciesResponse")]
        string[] getAllAvailableCurrencies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getAllAvailableCurrencies", ReplyAction="http://tempuri.org/IService1/getAllAvailableCurrenciesResponse")]
        System.Threading.Tasks.Task<string[]> getAllAvailableCurrenciesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : LibraryProject.CurrencyExchangeServiceReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<LibraryProject.CurrencyExchangeServiceReference.IService1>, LibraryProject.CurrencyExchangeServiceReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double ShowExchangeRate(string currencySymbol) {
            return base.Channel.ShowExchangeRate(currencySymbol);
        }
        
        public System.Threading.Tasks.Task<double> ShowExchangeRateAsync(string currencySymbol) {
            return base.Channel.ShowExchangeRateAsync(currencySymbol);
        }
        
        public double SellValue(string currencySymbol, double howManyCurrency) {
            return base.Channel.SellValue(currencySymbol, howManyCurrency);
        }
        
        public System.Threading.Tasks.Task<double> SellValueAsync(string currencySymbol, double howManyCurrency) {
            return base.Channel.SellValueAsync(currencySymbol, howManyCurrency);
        }
        
        public string[] getAllAvailableCurrencies() {
            return base.Channel.getAllAvailableCurrencies();
        }
        
        public System.Threading.Tasks.Task<string[]> getAllAvailableCurrenciesAsync() {
            return base.Channel.getAllAvailableCurrenciesAsync();
        }
    }
}
