Imports Amazon.CognitoIdentityProvider

Public Class loginException
    Inherits Amazon.CognitoIdentityProvider.Model.UserNotFoundException

    Public Sub New()
        MyBase.New("No se pudo completar el proceso de ingreso a la aplicacion")

    End Sub

End Class
