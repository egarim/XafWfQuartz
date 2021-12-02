;#DropDB XafWfQuartzEasyTest

#Application XafWfQuartzWin
;#Application XafWfQuartzWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef XafWfQuartzWin

*Action About...
 
*Action OK

#EndIf

#IfDef XafWfQuartzWeb
*Action Navigation(My Details)
#EndIf
