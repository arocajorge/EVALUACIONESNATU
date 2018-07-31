CREATE VIEW [dbo].[vw_reporte003]
AS
SELECT        ISNULL(ROW_NUMBER() OVER(ORDER BY rol_empleado_x_formulario.IdPeriodo ),0) AS IdRow, rol_empleado_x_formulario.IdPeriodo, rol_empleado_x_formulario.Secuencia, rol_empleado_x_formulario.Idempleado, rol_empleado_x_formulario.Idempleado_evaluado, 
                         evaluador.re_apellidos + ' ' + evaluador.re_nombres AS emp_evaluador, evaluado.re_apellidos + ' ' + evaluado.re_nombres AS emp_evaluado, enc_formulario.ef_descripcion, rol_empleado_x_formulario.ef_ponderacion, 
                         rol_empleado_x_formulario.ef_calificacion, rol_empleado_x_formulario.ef_calificacion_ponderacion
FROM            enc_formulario INNER JOIN
                         rol_empleado_x_formulario ON enc_formulario.IdFormulario = rol_empleado_x_formulario.IdFormulario AND enc_formulario.IdPeriodo = rol_empleado_x_formulario.IdPeriodo INNER JOIN
                         rol_empleado AS evaluador ON rol_empleado_x_formulario.Idempleado = evaluador.IdEmpleado INNER JOIN
                         rol_empleado AS evaluado ON rol_empleado_x_formulario.Idempleado_evaluado = evaluado.IdEmpleado
GROUP BY rol_empleado_x_formulario.IdPeriodo, rol_empleado_x_formulario.Secuencia, rol_empleado_x_formulario.Idempleado, rol_empleado_x_formulario.Idempleado_evaluado, evaluador.re_apellidos, evaluador.re_nombres, 
                         evaluado.re_apellidos, evaluado.re_nombres, enc_formulario.ef_descripcion, rol_empleado_x_formulario.ef_ponderacion, rol_empleado_x_formulario.ef_calificacion, rol_empleado_x_formulario.ef_calificacion_ponderacion
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_reporte003';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rol_empleado"
            Begin Extent = 
               Top = 138
               Left = 454
               Bottom = 268
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "enc_resolucion_calificacion"
            Begin Extent = 
               Top = 138
               Left = 662
               Bottom = 268
               Right = 862
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_reporte003';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
               Top = 6
               Left = 38
               Bottom = 136
               Right = 274
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "formulario"
            Begin Extent = 
               Top = 6
               Left = 312
               Bottom = 136
               Right = 482
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pregunta"
            Begin Extent = 
               Top = 6
               Left = 520
               Bottom = 136
               Right = 694
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "resolucion_det"
            Begin Extent = 
               Top = 6
               Left = 732
               Bottom = 136
               Right = 903
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "resolucion"
            Begin Extent = 
               Top = 6
               Left = 941
               Bottom = 136
               Right = 1146
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "emp_evaluado"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "emp_evalua"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 268
               Right = 416
            ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vw_reporte003';

