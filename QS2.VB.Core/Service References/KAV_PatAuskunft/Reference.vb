﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Dieser Code wurde von einem Tool generiert.
'     Laufzeitversion:4.0.30319.42000
'
'     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
'     der Code erneut generiert wird.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace KAV_PatAuskunft
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", ConfigurationName:="KAV_PatAuskunft.PatAuskunftSoap")>  _
    Public Interface PatAuskunftSoap
        
        'CODEGEN: Es wird ein Nachrichtenvertrag generiert, da Elementname XMLCallerInfo aus Namespace http://www.wienkav.at/kav/kav.datagate/PatAuskunft nicht als "nillable" (nullwertfähig) gekennzeichnet ist.
        <System.ServiceModel.OperationContractAttribute(Action:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft/GetAIDKette", ReplyAction:="*")>  _
        Function GetAIDKette(ByVal request As KAV_PatAuskunft.GetAIDKetteRequest) As KAV_PatAuskunft.GetAIDKetteResponse
        
        'CODEGEN: Es wird ein Nachrichtenvertrag generiert, da Elementname XMLCallerInfo aus Namespace http://www.wienkav.at/kav/kav.datagate/PatAuskunft nicht als "nillable" (nullwertfähig) gekennzeichnet ist.
        <System.ServiceModel.OperationContractAttribute(Action:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft/GetPatient", ReplyAction:="*")>  _
        Function GetPatient(ByVal request As KAV_PatAuskunft.GetPatientRequest) As KAV_PatAuskunft.GetPatientResponse
        
        'CODEGEN: Es wird ein Nachrichtenvertrag generiert, da Elementname XMLCallerInfo aus Namespace http://www.wienkav.at/kav/kav.datagate/PatAuskunft nicht als "nillable" (nullwertfähig) gekennzeichnet ist.
        <System.ServiceModel.OperationContractAttribute(Action:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft/GetBewegung", ReplyAction:="*")>  _
        Function GetBewegung(ByVal request As KAV_PatAuskunft.GetBewegungRequest) As KAV_PatAuskunft.GetBewegungResponse
        
        'CODEGEN: Es wird ein Nachrichtenvertrag generiert, da Elementname XMLCallerInfo aus Namespace http://www.wienkav.at/kav/kav.datagate/PatAuskunft nicht als "nillable" (nullwertfähig) gekennzeichnet ist.
        <System.ServiceModel.OperationContractAttribute(Action:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft/GetVoraufenthaltKette", ReplyAction:="*")>  _
        Function GetVoraufenthaltKette(ByVal request As KAV_PatAuskunft.GetVoraufenthaltKetteRequest) As KAV_PatAuskunft.GetVoraufenthaltKetteResponse
        
        'CODEGEN: Es wird ein Nachrichtenvertrag generiert, da Elementname XMLCallerInfo aus Namespace http://www.wienkav.at/kav/kav.datagate/PatAuskunft nicht als "nillable" (nullwertfähig) gekennzeichnet ist.
        <System.ServiceModel.OperationContractAttribute(Action:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft/GetData", ReplyAction:="*")>  _
        Function GetData(ByVal request As KAV_PatAuskunft.GetDataRequest) As KAV_PatAuskunft.GetDataResponse
        
        'CODEGEN: Es wird ein Nachrichtenvertrag generiert, da Elementname Part aus Namespace http://www.wienkav.at/kav/kav.datagate/PatAuskunft nicht als "nillable" (nullwertfähig) gekennzeichnet ist.
        <System.ServiceModel.OperationContractAttribute(Action:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft/GetVersion", ReplyAction:="*")>  _
        Function GetVersion(ByVal request As KAV_PatAuskunft.GetVersionRequest) As KAV_PatAuskunft.GetVersionResponse
        
        'CODEGEN: Es wird ein Nachrichtenvertrag generiert, da Elementname Password aus Namespace http://www.wienkav.at/kav/kav.datagate/PatAuskunft nicht als "nillable" (nullwertfähig) gekennzeichnet ist.
        <System.ServiceModel.OperationContractAttribute(Action:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft/ResetUserRights", ReplyAction:="*")>  _
        Function ResetUserRights(ByVal request As KAV_PatAuskunft.ResetUserRightsRequest) As KAV_PatAuskunft.ResetUserRightsResponse
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetAIDKetteRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetAIDKette", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetAIDKetteRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetAIDKetteRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetAIDKetteRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public XMLCallerInfo As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=1)>  _
        Public XML As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal XMLCallerInfo As String, ByVal XML As String)
            MyBase.New
            Me.XMLCallerInfo = XMLCallerInfo
            Me.XML = XML
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetAIDKetteResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetAIDKetteResponse", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetAIDKetteResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetAIDKetteResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetAIDKetteResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public GetAIDKetteResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal GetAIDKetteResult As String)
            MyBase.New
            Me.GetAIDKetteResult = GetAIDKetteResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetPatientRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetPatient", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetPatientRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetPatientRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetPatientRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public XMLCallerInfo As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=1)>  _
        Public XML As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal XMLCallerInfo As String, ByVal XML As String)
            MyBase.New
            Me.XMLCallerInfo = XMLCallerInfo
            Me.XML = XML
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetPatientResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetPatientResponse", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetPatientResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetPatientResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetPatientResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public GetPatientResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal GetPatientResult As String)
            MyBase.New
            Me.GetPatientResult = GetPatientResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetBewegungRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetBewegung", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetBewegungRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetBewegungRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetBewegungRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public XMLCallerInfo As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=1)>  _
        Public XML As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal XMLCallerInfo As String, ByVal XML As String)
            MyBase.New
            Me.XMLCallerInfo = XMLCallerInfo
            Me.XML = XML
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetBewegungResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetBewegungResponse", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetBewegungResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetBewegungResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetBewegungResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public GetBewegungResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal GetBewegungResult As String)
            MyBase.New
            Me.GetBewegungResult = GetBewegungResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetVoraufenthaltKetteRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetVoraufenthaltKette", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetVoraufenthaltKetteRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetVoraufenthaltKetteRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetVoraufenthaltKetteRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public XMLCallerInfo As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=1)>  _
        Public XML As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal XMLCallerInfo As String, ByVal XML As String)
            MyBase.New
            Me.XMLCallerInfo = XMLCallerInfo
            Me.XML = XML
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetVoraufenthaltKetteResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetVoraufenthaltKetteResponse", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetVoraufenthaltKetteResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetVoraufenthaltKetteResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetVoraufenthaltKetteResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public GetVoraufenthaltKetteResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal GetVoraufenthaltKetteResult As String)
            MyBase.New
            Me.GetVoraufenthaltKetteResult = GetVoraufenthaltKetteResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetDataRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetData", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetDataRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetDataRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetDataRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public XMLCallerInfo As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=1)>  _
        Public Result As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=2)>  _
        Public Resultfilter As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=3)>  _
        Public ID1 As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=4)>  _
        Public ID2 As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=5)>  _
        Public ID3 As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=6)>  _
        Public ID4 As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=7)>  _
        Public ID5 As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal XMLCallerInfo As String, ByVal Result As String, ByVal Resultfilter As String, ByVal ID1 As String, ByVal ID2 As String, ByVal ID3 As String, ByVal ID4 As String, ByVal ID5 As String)
            MyBase.New
            Me.XMLCallerInfo = XMLCallerInfo
            Me.Result = Result
            Me.Resultfilter = Resultfilter
            Me.ID1 = ID1
            Me.ID2 = ID2
            Me.ID3 = ID3
            Me.ID4 = ID4
            Me.ID5 = ID5
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetDataResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetDataResponse", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetDataResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetDataResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetDataResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public GetDataResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal GetDataResult As String)
            MyBase.New
            Me.GetDataResult = GetDataResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetVersionRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetVersion", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetVersionRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetVersionRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetVersionRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public Part As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Part As String)
            MyBase.New
            Me.Part = Part
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class GetVersionResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="GetVersionResponse", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.GetVersionResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.GetVersionResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class GetVersionResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public GetVersionResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal GetVersionResult As String)
            MyBase.New
            Me.GetVersionResult = GetVersionResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class ResetUserRightsRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="ResetUserRights", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.ResetUserRightsRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.ResetUserRightsRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft")>  _
    Partial Public Class ResetUserRightsRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public Password As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Password As String)
            MyBase.New
            Me.Password = Password
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class ResetUserRightsResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="ResetUserRightsResponse", [Namespace]:="http://www.wienkav.at/kav/kav.datagate/PatAuskunft", Order:=0)>  _
        Public Body As KAV_PatAuskunft.ResetUserRightsResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As KAV_PatAuskunft.ResetUserRightsResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute()>  _
    Partial Public Class ResetUserRightsResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface PatAuskunftSoapChannel
        Inherits KAV_PatAuskunft.PatAuskunftSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class PatAuskunftSoapClient
        Inherits System.ServiceModel.ClientBase(Of KAV_PatAuskunft.PatAuskunftSoap)
        Implements KAV_PatAuskunft.PatAuskunftSoap
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function KAV_PatAuskunft_PatAuskunftSoap_GetAIDKette(ByVal request As KAV_PatAuskunft.GetAIDKetteRequest) As KAV_PatAuskunft.GetAIDKetteResponse Implements KAV_PatAuskunft.PatAuskunftSoap.GetAIDKette
            Return MyBase.Channel.GetAIDKette(request)
        End Function
        
        Public Function GetAIDKette(ByVal XMLCallerInfo As String, ByVal XML As String) As String
            Dim inValue As KAV_PatAuskunft.GetAIDKetteRequest = New KAV_PatAuskunft.GetAIDKetteRequest()
            inValue.Body = New KAV_PatAuskunft.GetAIDKetteRequestBody()
            inValue.Body.XMLCallerInfo = XMLCallerInfo
            inValue.Body.XML = XML
            Dim retVal As KAV_PatAuskunft.GetAIDKetteResponse = CType(Me,KAV_PatAuskunft.PatAuskunftSoap).GetAIDKette(inValue)
            Return retVal.Body.GetAIDKetteResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function KAV_PatAuskunft_PatAuskunftSoap_GetPatient(ByVal request As KAV_PatAuskunft.GetPatientRequest) As KAV_PatAuskunft.GetPatientResponse Implements KAV_PatAuskunft.PatAuskunftSoap.GetPatient
            Return MyBase.Channel.GetPatient(request)
        End Function
        
        Public Function GetPatient(ByVal XMLCallerInfo As String, ByVal XML As String) As String
            Dim inValue As KAV_PatAuskunft.GetPatientRequest = New KAV_PatAuskunft.GetPatientRequest()
            inValue.Body = New KAV_PatAuskunft.GetPatientRequestBody()
            inValue.Body.XMLCallerInfo = XMLCallerInfo
            inValue.Body.XML = XML
            Dim retVal As KAV_PatAuskunft.GetPatientResponse = CType(Me,KAV_PatAuskunft.PatAuskunftSoap).GetPatient(inValue)
            Return retVal.Body.GetPatientResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function KAV_PatAuskunft_PatAuskunftSoap_GetBewegung(ByVal request As KAV_PatAuskunft.GetBewegungRequest) As KAV_PatAuskunft.GetBewegungResponse Implements KAV_PatAuskunft.PatAuskunftSoap.GetBewegung
            Return MyBase.Channel.GetBewegung(request)
        End Function
        
        Public Function GetBewegung(ByVal XMLCallerInfo As String, ByVal XML As String) As String
            Dim inValue As KAV_PatAuskunft.GetBewegungRequest = New KAV_PatAuskunft.GetBewegungRequest()
            inValue.Body = New KAV_PatAuskunft.GetBewegungRequestBody()
            inValue.Body.XMLCallerInfo = XMLCallerInfo
            inValue.Body.XML = XML
            Dim retVal As KAV_PatAuskunft.GetBewegungResponse = CType(Me,KAV_PatAuskunft.PatAuskunftSoap).GetBewegung(inValue)
            Return retVal.Body.GetBewegungResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function KAV_PatAuskunft_PatAuskunftSoap_GetVoraufenthaltKette(ByVal request As KAV_PatAuskunft.GetVoraufenthaltKetteRequest) As KAV_PatAuskunft.GetVoraufenthaltKetteResponse Implements KAV_PatAuskunft.PatAuskunftSoap.GetVoraufenthaltKette
            Return MyBase.Channel.GetVoraufenthaltKette(request)
        End Function
        
        Public Function GetVoraufenthaltKette(ByVal XMLCallerInfo As String, ByVal XML As String) As String
            Dim inValue As KAV_PatAuskunft.GetVoraufenthaltKetteRequest = New KAV_PatAuskunft.GetVoraufenthaltKetteRequest()
            inValue.Body = New KAV_PatAuskunft.GetVoraufenthaltKetteRequestBody()
            inValue.Body.XMLCallerInfo = XMLCallerInfo
            inValue.Body.XML = XML
            Dim retVal As KAV_PatAuskunft.GetVoraufenthaltKetteResponse = CType(Me,KAV_PatAuskunft.PatAuskunftSoap).GetVoraufenthaltKette(inValue)
            Return retVal.Body.GetVoraufenthaltKetteResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function KAV_PatAuskunft_PatAuskunftSoap_GetData(ByVal request As KAV_PatAuskunft.GetDataRequest) As KAV_PatAuskunft.GetDataResponse Implements KAV_PatAuskunft.PatAuskunftSoap.GetData
            Return MyBase.Channel.GetData(request)
        End Function
        
        Public Function GetData(ByVal XMLCallerInfo As String, ByVal Result As String, ByVal Resultfilter As String, ByVal ID1 As String, ByVal ID2 As String, ByVal ID3 As String, ByVal ID4 As String, ByVal ID5 As String) As String
            Dim inValue As KAV_PatAuskunft.GetDataRequest = New KAV_PatAuskunft.GetDataRequest()
            inValue.Body = New KAV_PatAuskunft.GetDataRequestBody()
            inValue.Body.XMLCallerInfo = XMLCallerInfo
            inValue.Body.Result = Result
            inValue.Body.Resultfilter = Resultfilter
            inValue.Body.ID1 = ID1
            inValue.Body.ID2 = ID2
            inValue.Body.ID3 = ID3
            inValue.Body.ID4 = ID4
            inValue.Body.ID5 = ID5
            Dim retVal As KAV_PatAuskunft.GetDataResponse = CType(Me,KAV_PatAuskunft.PatAuskunftSoap).GetData(inValue)
            Return retVal.Body.GetDataResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function KAV_PatAuskunft_PatAuskunftSoap_GetVersion(ByVal request As KAV_PatAuskunft.GetVersionRequest) As KAV_PatAuskunft.GetVersionResponse Implements KAV_PatAuskunft.PatAuskunftSoap.GetVersion
            Return MyBase.Channel.GetVersion(request)
        End Function
        
        Public Function GetVersion(ByVal Part As String) As String
            Dim inValue As KAV_PatAuskunft.GetVersionRequest = New KAV_PatAuskunft.GetVersionRequest()
            inValue.Body = New KAV_PatAuskunft.GetVersionRequestBody()
            inValue.Body.Part = Part
            Dim retVal As KAV_PatAuskunft.GetVersionResponse = CType(Me,KAV_PatAuskunft.PatAuskunftSoap).GetVersion(inValue)
            Return retVal.Body.GetVersionResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function KAV_PatAuskunft_PatAuskunftSoap_ResetUserRights(ByVal request As KAV_PatAuskunft.ResetUserRightsRequest) As KAV_PatAuskunft.ResetUserRightsResponse Implements KAV_PatAuskunft.PatAuskunftSoap.ResetUserRights
            Return MyBase.Channel.ResetUserRights(request)
        End Function
        
        Public Sub ResetUserRights(ByVal Password As String)
            Dim inValue As KAV_PatAuskunft.ResetUserRightsRequest = New KAV_PatAuskunft.ResetUserRightsRequest()
            inValue.Body = New KAV_PatAuskunft.ResetUserRightsRequestBody()
            inValue.Body.Password = Password
            Dim retVal As KAV_PatAuskunft.ResetUserRightsResponse = CType(Me,KAV_PatAuskunft.PatAuskunftSoap).ResetUserRights(inValue)
        End Sub
    End Class
End Namespace