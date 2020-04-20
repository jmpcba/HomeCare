Imports Amazon.CognitoIdentityProvider
Public Class UserConformationException
    Inherits AmazonCognitoIdentityProviderException

    Public Sub New(_message As String)
        MyBase.New(_message)
    End Sub
End Class
