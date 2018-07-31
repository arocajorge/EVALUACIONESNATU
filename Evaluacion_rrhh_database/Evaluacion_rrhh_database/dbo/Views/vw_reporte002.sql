CREATE VIEW dbo.vw_reporte002
AS
SELECT        emp_evaluado.IdEmpleado, dbo.rol_empleado_x_formulario.IdPeriodo, emp_evaluado.re_codigo AS re_codigo_eva, emp_evaluado.re_apellidos AS re_apellidos_eva, emp_evaluado.re_nombres AS re_nombres_eva, 
                         emp_evaluado.re_cedula, dbo.rol_empleado.re_codigo, dbo.rol_empleado.re_apellidos, dbo.rol_empleado.re_nombres, formulario.ef_descripcion, pregunta.ep_descripcion, resolucion_det.re_ponderacion, 
                         pregunta.ep_ponderacion, resolucion_det.re_ponderacion * pregunta.ep_ponderacion / 100 AS Ponderacion_x_pregunta, dbo.rol_empleado_x_formulario.ef_ponderacion, dbo.rol_empleado_x_formulario.ef_calificacion, 
                         dbo.rol_empleado_x_formulario.ef_calificacion_ponderacion, dbo.rol_empleado_x_formulario.Idempleado_evaluado, dbo.enc_resolucion_calificacion.Calificacion, dbo.enc_resolucion_calificacion.factor_cumplimiento, 
                         dbo.enc_resolucion_calificacion.calificacion_final
FROM            dbo.rol_empleado_x_formulario INNER JOIN
                         dbo.enc_formulario AS formulario INNER JOIN
                         dbo.enc_formulario_pregunta AS pregunta INNER JOIN
                         dbo.enc_resolucion_formulario_det AS resolucion_det INNER JOIN
                         dbo.enc_resolucion_formulario AS resolucion ON resolucion_det.IdResolucion = resolucion.IdResolucion ON pregunta.IdPregunta = resolucion_det.IdPregunta ON formulario.IdFormulario = pregunta.IdFormulario AND 
                         formulario.IdPeriodo = pregunta.IdPeriodo ON dbo.rol_empleado_x_formulario.IdPeriodo = resolucion.IdPeriodo AND dbo.rol_empleado_x_formulario.Idempleado = resolucion.IdEmpleado AND 
                         dbo.rol_empleado_x_formulario.Idempleado_evaluado = resolucion.IdEmpleado_evaluado INNER JOIN
                         dbo.rol_empleado AS emp_evaluado ON dbo.rol_empleado_x_formulario.Idempleado_evaluado = emp_evaluado.IdEmpleado INNER JOIN
                         dbo.rol_empleado AS emp_evalua ON dbo.rol_empleado_x_formulario.Idempleado = emp_evalua.IdEmpleado INNER JOIN
                         dbo.rol_empleado ON dbo.rol_empleado_x_formulario.Idempleado = dbo.rol_empleado.IdEmpleado INNER JOIN
                         dbo.enc_resolucion_calificacion ON dbo.rol_empleado_x_formulario.Idempleado_evaluado = dbo.enc_resolucion_calificacion.IdEmpleado AND 
                         dbo.rol_empleado_x_formulario.IdPeriodo = dbo.enc_resolucion_calificacion.IdPeriodo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_reporte002';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'      End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rol_empleado"
            Begin Extent = 
               Top = 19
               Left = 528
               Bottom = 254
               Right = 698
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "enc_resolucion_calificacion"
            Begin Extent = 
               Top = 194
               Left = 41
               Bottom = 387
               Right = 337
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 20
         Width = 284
         Width = 1500
         Width = 1500
         Width = 2280
         Width = 1500
         Width = 3645
         Width = 3510
         Width = 2910
         Width = 1500
         Width = 2775
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_reporte002';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[47] 4[3] 2[3] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "rol_empleado_x_formulario"
            Begin Extent = 
               Top = 222
               Left = 437
               Bottom = 437
               Right = 673
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "formulario"
            Begin Extent = 
               Top = 0
               Left = 34
               Bottom = 192
               Right = 299
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pregunta"
            Begin Extent = 
               Top = 0
               Left = 333
               Bottom = 185
               Right = 542
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "resolucion_det"
            Begin Extent = 
               Top = 326
               Left = 994
               Bottom = 502
               Right = 1257
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "resolucion"
            Begin Extent = 
               Top = 152
               Left = 832
               Bottom = 346
               Right = 1210
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "emp_evaluado"
            Begin Extent = 
               Top = 276
               Left = 566
               Bottom = 572
               Right = 736
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "emp_evalua"
            Begin Extent = 
               Top = 0
               Left = 1012
               Bottom = 185
               Right = 1182
      ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_reporte002';



