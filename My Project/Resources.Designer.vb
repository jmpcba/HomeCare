﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'StronglyTypedResourceBuilder generó automáticamente esta clase
    'a través de una herramienta como ResGen o Visual Studio.
    'Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    'con la opción /str o recompile su proyecto de VS.
    '''<summary>
    '''  Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Public Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("HomeCare.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        '''  búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a &lt;html&gt;
        '''	&lt;p&gt;Buenos dias &lt;/br&gt;
        '''	los honorarios por prestaciones realizadas en el mes de &lt;b&gt;[MES] [YEAR]&lt;/b&gt; son de: &lt;br&gt;
        '''	&lt;/br&gt;
        '''
        '''	&lt;b&gt;HORAS PRACTICAS LUNES A VIERNES:&lt;/b&gt; [HS_LAV] &lt;br&gt;
        '''	&lt;b&gt;HORAS PRACTICAS FERIADOS Y DOMINGOS:&lt;/b&gt; [HS_FER] &lt;br&gt;
        '''	&lt;/br&gt;
        '''	&lt;b&gt;MONTO LUNES A VIERNES:&lt;/b&gt; [MONTO_LAV] &lt;br&gt;
        '''	&lt;b&gt;MONTO FERIADOS:&lt;/b&gt; [MONTO_FER] &lt;br&gt;
        '''	&lt;b&gt;MONTO FIJO:&lt;/b&gt; [MONTO_FIJO] &lt;br&gt;
        '''	&lt;br&gt;
        '''	Cualquier duda o consulta sobre el calculo de prestaciones, comunicarse a este email.
        '''	&lt;br&gt;
        '''	&lt;br&gt;
        '''	&lt;br&gt;
        '''	&lt;center&gt;* [resto de la cadena truncado]&quot;;.
        '''</summary>
        Public ReadOnly Property mailTemplate() As String
            Get
                Return ResourceManager.GetString("mailTemplate", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
