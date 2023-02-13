
Imports System
Imports System.IO.Ports

Module Module1

    Sub Main()
        Dim USE_SERIAL As SerialPort
        USE_SERIAL = New SerialPort()
        Dim port As String
        GetSerialPorts()

        Console.Write("Elija el puerto a utilizar: ")
        port = Console.ReadLine()

        Try
            ' Config... '
            'USE_SERIAL.BaudRate = 9600
            'USE_SERIAL.Parity = Parity.None
            'USE_SERIAL.DataBits = 8
            'USE_SERIAL.StopBits = StopBits.None
            USE_SERIAL.PortName = port
            USE_SERIAL.Open()
            AddHandler USE_SERIAL.DataReceived, AddressOf DataReceivedHandler

        Catch ex As Exception
            Console.WriteLine("Error al conectarse al puerto:" + port)
        End Try


    End Sub

    Sub GetSerialPorts()
        'Muestra los puertos disponibles'
        Console.Write("Los puertos disponibles son: ")
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Console.WriteLine("•" + sp)
        Next
    End Sub
    Sub DataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        'Maneja el evento de recibir información desde el puertoSerial'
        Dim sp As SerialPort = DirectCast(sender, SerialPort)
        Dim indata As String = sp.ReadExisting()
        Console.WriteLine("Data enviada desde el micro:")
        Console.WriteLine(indata)

    End Sub
End Module
