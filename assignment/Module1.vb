Module Module1
    Class booking
        Public clientname As String
        Public clientaddress As String
        Public phonenumbers As Integer
        Public dateofbooking As Date
        Public timeofbooking As Date
        Public complete As Boolean
        Public hours As Integer


    End Class
    Class company
        Public companyname As String
        Public companyowner As String
        Public contactnumber As Integer
        Public address As String
        Public pay As Single
        Public hours As Integer
        Public hourlypay As Integer


    End Class

    Dim companys As New company
    Dim companyInfo As New company
    Dim newbooking As New List(Of booking)

    Function getbookingnum()

        Dim index As Integer = 0
        Console.Clear()
        Console.Clear()
        Console.WriteLine("Viewing incomplete jobs")
        Console.WriteLine()
        Console.WriteLine("{0,-5} {1,-25} {2,-20} {3,-20}", "Id", "Client's name", "Date", "Time")
        Console.WriteLine("=============================================")

        For i = 0 To newbooking.Count - 1
            Console.WriteLine("{0,-5} {1,-25} {2,-25} {3,-20}", i, newbooking(i).clientname, newbooking(i).dateofbooking, newbooking(i).timeofbooking)
        Next
        Console.WriteLine("=============================================")

        Console.Write("Enter the ID of the booking to edit <-1 to cancel>: ")
        index = Console.ReadLine()
        Return index

    End Function
    Sub loadCompanyinfo()

        FileOpen(1, "CompanyInfo.txt", OpenMode.Input)

        companys.companyname = LineInput(1)
        companys.companyowner = LineInput(1)
        companys.contactnumber = LineInput(1)
        companys.address = LineInput(1)
        companys.pay = LineInput(1)
        companys.hours = LineInput(1)
        FileClose(1)

    End Sub

    Sub MakeCompanyInfo()
        Console.Clear()
        Console.WriteLine("No company information has been found. We'll setup a profile before we begin.")
        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()
        Console.Clear()
        Console.WriteLine("Here you need to enter the details for your new company profile.")
        Console.WriteLine()
        Console.Write("Company name: ")
        companys.companyname = Console.ReadLine()
        Console.Write("Company owner's name: ")
        companys.companyowner = Console.ReadLine()
        Console.Write("Company contact number: ")
        companys.contactnumber = Console.ReadLine()
        Console.Write("Company address: ")
        companys.address = Console.ReadLine()
        Console.Write("Company hourly rate: $")
        companys.hourlypay = Console.ReadLine()
        Console.WriteLine()
        Console.WriteLine("Setup is complete!")
        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()

        FileOpen(1, "CompanyInfo.txt", OpenMode.Output)


        PrintLine(1, companys.companyname)
        PrintLine(1, companys.companyowner)
        PrintLine(1, companys.contactnumber)
        PrintLine(1, companys.address)
        PrintLine(1, companys.pay)
        PrintLine(1, companys.hours)
        PrintLine(1, companys.hourlypay)



        FileClose(1)

    End Sub
    Sub save()
        FileOpen(1, "CompanyInfo.txt", OpenMode.Output)


        PrintLine(1, companys.companyname)
        PrintLine(1, companys.companyowner)
        PrintLine(1, companys.contactnumber)
        PrintLine(1, companys.address)
        PrintLine(1, companys.pay)
        PrintLine(1, companys.hours)
        PrintLine(1, companys.hourlypay)



        FileClose(1)
    End Sub
    Sub loadbookings()

        If IO.File.Exists("BookingData.txt") Then

            FileOpen(2, "BookingData.txt", OpenMode.Input)
            While Not EOF(2)

                Dim booking As New booking

                booking.clientname = LineInput(2)
                booking.clientaddress = LineInput(2)
                booking.phonenumbers = LineInput(2)
                booking.dateofbooking = LineInput(2)
                booking.timeofbooking = LineInput(2)
                booking.complete = LineInput(2)
                booking.hours = LineInput(2)
                newbooking.Add(booking)

            End While

            FileClose(2)

        End If

    End Sub
    Sub savebookings()
        FileOpen(2, "BookingData.txt", OpenMode.Output)
        For i = 0 To newbooking.Count - 1
            PrintLine(2, newbooking(i).clientname)
            PrintLine(2, newbooking(i).clientaddress)
            PrintLine(2, newbooking(i).phonenumbers)
            PrintLine(2, newbooking(i).dateofbooking)
            PrintLine(2, newbooking(i).timeofbooking)
            PrintLine(2, newbooking(i).complete)
            PrintLine(2, newbooking(i).hours)
        Next

        FileClose(2)
    End Sub
    Sub addbooking()

        Dim booking As New booking
        Console.Clear()

        Console.WriteLine("Adding a new booking, enter the details below")
        Console.WriteLine()
        Console.Write("Client's name: ")
        booking.clientname = Console.ReadLine
        Console.Write("Client's address: ")
        booking.clientaddress = Console.ReadLine
        Console.Write("Contact number: ")
        booking.phonenumbers = Console.ReadLine
        Console.Write("Date of booking (DD/MM/YY): ")
        booking.dateofbooking = Console.ReadLine
        Console.Write("Time of booking (HH:MM AM/PM): ")
        booking.timeofbooking = Console.ReadLine

        newbooking.Add(booking)

    End Sub
    Sub viewbookings(complete As Boolean)
        Console.Clear()
        Console.WriteLine("Viewing incomplete jobs")
        Console.WriteLine()
        Console.WriteLine("{0,-25} {1,-10} {2,-10}", "Client's name", "Date", "Time")
        Console.WriteLine("=============================================")
        For i = 0 To newbooking.Count - 1
            If newbooking(i).complete = complete Then
                Console.WriteLine("{0,-25} {1,-10} {2,-10}", newbooking(i).clientname, newbooking(i).dateofbooking.ToString("MM/dd/yy"), newbooking(i).timeofbooking.ToString("H:mm tt"))
            End If
        Next
        Console.WriteLine("=============================================")
        Console.Write("press any key to continue...")
        Console.ReadKey()
    End Sub
    Sub checkincompletebookings()

    End Sub
    Sub viewincompletebookings(complete As Boolean)
        Console.Clear()
        If newbooking.Count = 0 Then
            Console.WriteLine("There are no bookings on this program.")
        Else
            Dim index As Integer = getbookingnum()
            If index >= 0 And index < newbooking.Count Then

                Console.Clear()

                Console.WriteLine("Booking details: ")
                Console.WriteLine()
                Console.WriteLine("        " & newbooking(index).clientname)
                Console.WriteLine("        " & newbooking(index).clientaddress)
                Console.WriteLine("        " & newbooking(index).phonenumbers)
                Console.WriteLine("        " & newbooking(index).dateofbooking.ToString("MM/dd/yy"))
                Console.WriteLine("        " & newbooking(index).timeofbooking.ToString("H:mm tt"))
                Console.WriteLine()
                Console.WriteLine("Press any key to continue...")

            End If
        End If
        Console.ReadKey()
    End Sub
    Sub editincompletebookings()
        Console.Clear()
        If newbooking.Count = 0 Then
            Console.WriteLine("There are no bookings on this program.")
        Else
            Dim index As Integer = getbookingnum()
            If index >= 0 And index < newbooking.Count Then
                Console.Clear()
                Dim name As String
                Dim address As String
                Dim numbers As String
                Dim dates As String
                Dim time As String
                Console.WriteLine("Booking details: ")
                Console.WriteLine()
                Console.WriteLine("        " & newbooking(index).clientname)
                Console.WriteLine("        " & newbooking(index).clientaddress)
                Console.WriteLine("        " & newbooking(index).phonenumbers)
                Console.WriteLine("        " & newbooking(index).dateofbooking.ToString("MM/dd/yy"))
                Console.WriteLine("        " & newbooking(index).timeofbooking.ToString("H:mm tt"))
                Console.WriteLine()

                Console.WriteLine("New booking details <just press enter to retain original values>:")
                Console.WriteLine()
                Console.Write("Client's name: ")
                name = Console.ReadLine
                Console.Write("Client's address: ")
                address = Console.ReadLine
                Console.Write("Contact number: ")
                numbers = Console.ReadLine
                Console.Write("Date of booking (DD/MM/YY): ")
                dates = Console.ReadLine
                Console.Write("Time of booking (HH:MM AM/PM): ")
                time = Console.ReadLine
                If name <> "" Then
                    newbooking(index).clientname = name
                End If
                If address <> "" Then
                    newbooking(index).clientaddress = address
                End If
                If numbers <> "" Then
                    newbooking(index).phonenumbers = numbers
                End If
                If dates <> "" Then
                    newbooking(index).dateofbooking = dates
                End If
                If time <> "" Then
                    newbooking(index).timeofbooking = time
                End If
                Console.WriteLine("Update complete!")
                Console.WriteLine()
                Console.WriteLine("Press any key to continue...")
                Console.ReadKey()

            End If
        End If
    End Sub
    Sub removebooking()
        Console.Clear()
        If newbooking.Count = 0 Then
            Console.WriteLine("There are no bookings on this program.")
        Else
            Dim index As Integer = getbookingnum()
            If index >= 0 And index < newbooking.Count Then
                Dim ans As Char
                Console.WriteLine("Are you sure its completed <y/n>: ")
                ans = Console.ReadKey(True).KeyChar.ToString.ToUpper
                If ans = "Y" Then
                    newbooking.RemoveAt(index)
                    Console.WriteLine("booking has been removed!")
                End If
            End If

        End If
        Console.ReadLine()
    End Sub
    Sub completedbooking()
        Console.Clear()
        Dim answers As Char
        If newbooking.Count = 0 Then
            Console.WriteLine("There are no bookings in this program.")
        Else
            Dim index As Integer = getbookingnum()

            'Check we are good
            If index > -1 And index < newbooking.Count Then
                Console.Clear()
                Console.WriteLine("Name: " & newbooking(index).clientname)
                Console.WriteLine("Address: " & newbooking(index).clientaddress)
                Console.WriteLine("Phone Number: " & newbooking(index).phonenumbers)
                Console.WriteLine("Date: " & newbooking(index).dateofbooking.ToString("MM/dd/yy"))
                Console.WriteLine("Time: " & newbooking(index).timeofbooking.ToString("H:mm tt"))
                Console.WriteLine()
                Console.WriteLine("Are you sure its completed <y/n>: ")
                answers = Console.ReadKey(True).KeyChar.ToString.ToUpper
                If answers = "Y" Then
                    newbooking(index).complete = True
                    Console.Clear()
                    Console.Write("how many hours did it take to finish job: ")
                    newbooking(index).hours = Console.ReadLine
                    companys.hours = companys.hours + newbooking(index).hours
                Else
                    Console.WriteLine("Press any key to continue...")
                End If

            End If
        End If

        Console.ReadKey()


    End Sub
    Sub viewbusinesscard()
        Console.Clear()
        Console.SetCursorPosition(13, 7)
        Console.WriteLine("/============================================\")
        Console.SetCursorPosition(13, 8)
        Console.Write("|  " & companys.companyname)
        Console.SetCursorPosition(58, 8)
        Console.WriteLine("|")
        Console.SetCursorPosition(13, 9)
        Console.WriteLine("|")
        Console.SetCursorPosition(58, 9)
        Console.WriteLine("|")
        Console.SetCursorPosition(13, 10)
        Console.WriteLine("|  Owner: " & companys.companyowner)
        Console.SetCursorPosition(58, 10)
        Console.WriteLine("|")
        Console.SetCursorPosition(13, 11)
        Console.WriteLine("|")
        Console.SetCursorPosition(58, 11)
        Console.WriteLine("|")
        Console.SetCursorPosition(13, 12)
        Console.WriteLine("|")
        Console.SetCursorPosition(58, 12)
        Console.WriteLine("|")
        Console.SetCursorPosition(13, 13)
        Console.WriteLine("|  Phone Number: " & companys.contactnumber)
        Console.SetCursorPosition(58, 13)
        Console.WriteLine("|")
        Console.SetCursorPosition(13, 14)
        Console.WriteLine("|  Address: " & companys.address)
        Console.SetCursorPosition(58, 14)
        Console.WriteLine("|")
        Console.SetCursorPosition(13, 15)
        Console.WriteLine("|")
        Console.SetCursorPosition(58, 15)
        Console.WriteLine("|")
        Console.SetCursorPosition(13, 16)
        Console.WriteLine("\============================================/")


        Console.ReadKey()

    End Sub

    Sub menu()
        Dim selection As Char

        Do
            companys.pay = companys.hours * companys.hourlypay
            Console.Clear()
            Console.WriteLine("Welcome " & companys.companyowner)
            Console.WriteLine("--------------------------------------------------")
            Console.WriteLine("Total completed hours: " & companys.hours)
            Console.WriteLine("Total income:          $" & companys.pay)
            Console.WriteLine("--------------------------------------------------")
            Console.WriteLine()
            Console.WriteLine("Select from one of the following menu options:")
            Console.WriteLine()
            Console.SetCursorPosition(2, 8)
            Console.WriteLine("<A> Add a booking")
            Console.SetCursorPosition(2, 9)
            Console.WriteLine("<B> View all incomplete booking")
            Console.SetCursorPosition(2, 10)
            Console.WriteLine("<C> View all complete booking")
            Console.SetCursorPosition(2, 11)
            Console.WriteLine("<D> Check incomplete bookings for next 7 days")
            Console.SetCursorPosition(2, 13)
            Console.WriteLine("<E> View incomplete booking's details")
            Console.SetCursorPosition(2, 14)
            Console.WriteLine("<F> Edit incomplete booking details")
            Console.SetCursorPosition(2, 16)
            Console.WriteLine("<G> Remove a booking")
            Console.SetCursorPosition(2, 17)
            Console.WriteLine("<H> Complete a booking")
            Console.SetCursorPosition(2, 19)
            Console.WriteLine("<I> View Business card")
            Console.SetCursorPosition(2, 21)
            Console.WriteLine("<X> Exit")
            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper
            Select Case selection
                Case "A"
                    addbooking()
                Case "B"
                    viewbookings(False)
                Case "C"
                    viewbookings(True)
                Case "D"
                    checkincompletebookings()
                Case "E"
                    viewincompletebookings(False)
                Case "F"
                    editincompletebookings()
                Case "G"
                    removebooking()
                Case "H"
                    completedbooking()
                Case "I"
                    viewbusinesscard()
            End Select

        Loop Until selection = "X"



    End Sub

    Sub Main()

        Console.ForegroundColor = ConsoleColor.Red
        Console.SetCursorPosition(23, 0)
        Console.WriteLine("Welcome to Fun With Lawns v0.1")
        Console.SetCursorPosition(18, 1)
        Console.WriteLine("Your all in one lawn management system.")
        Console.SetCursorPosition(20, 3)
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()
        If Not IO.File.Exists("CompanyInfo.txt") Then
            MakeCompanyInfo()
            menu()
            save()

            Console.Clear()

        Else

            loadCompanyinfo()
            loadbookings()
            menu()
            save()
            savebookings()



        End If
    End Sub

End Module
