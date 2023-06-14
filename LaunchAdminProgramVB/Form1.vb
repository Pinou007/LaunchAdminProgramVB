Imports System.Diagnostics
Imports System.IO
Imports System.Threading

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim configFilePath As String = Path.Combine(Application.StartupPath, "Config.pinou007")
        Dim processInfo As New ProcessStartInfo()

        ' Vérifier si le fichier de configuration existe
        If File.Exists(configFilePath) Then
            ' Lire le nom du programme à lancer depuis le fichier de configuration
            Dim programName As String = File.ReadAllText(configFilePath)

            ' Configurer les informations du processus
            processInfo.FileName = programName
            processInfo.UseShellExecute = True
            processInfo.Verb = "runas" ' Demande d'élévation des privilèges administratifs

            ' Lancer le processus
            Try
                Thread.Sleep(1000)
                Process.Start(processInfo)


            Catch ex As Exception
                ' Gérer les erreurs lors du lancement du processus
                MsgBox("Une erreur s'est produite : " & ex.Message)

            End Try
        Else
            ' Fichier de configuration introuvable
            MsgBox("Le fichier de configuration est introuvable.")
            End
        End If
        End

    End Sub
End Class
