﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace workinggg2
{

    public partial class MainWindow : Window

    {
        private bool isDrawing = false;
        private Point startPoint;
        private SolidColorBrush brushColor = Brushes.Black;
        private double brushSize = 5;
        private Shape currentShape;

        public MainWindow()
        {
            InitializeComponent();
            BrushSizeSlider.ValueChanged += BrushSizeSlider_ValueChanged;
            ColorComboBox.SelectionChanged += ColorComboBox_1;
        }

        private void ColorComboBox_1(object sender, SelectionChangedEventArgs e)
        {
            if (ColorComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string colorName = selectedItem.Content.ToString();
                brushColor = (SolidColorBrush) new BrushConverter().ConvertFromString(colorName);
            }
        }

        private void BrushSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs <double> e)
        {
            brushSize = e.NewValue;
        }

        private void DrawModeToggle_Checked(object sender, RoutedEventArgs e)
        {
            ResetOtherModes(DrawModeToggle);
        }

        private void EditModeToggle_Checked(object sender, RoutedEventArgs e)
        {
            ResetOtherModes(EditModeToggle);
        }

        private void DeleteModeToggle_Checked(object sender, RoutedEventArgs e)
        {
            ResetOtherModes(DeleteModeToggle);
        }
        private void DrawModeToggle_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void EditModeToggle_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteModeToggle_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void ResetOtherModes(ToggleButton activeMode)
        {
            if (activeMode != DrawModeToggle) DrawModeToggle.IsChecked = false;
            if (activeMode != EditModeToggle) EditModeToggle.IsChecked = false;
            if (activeMode != DeleteModeToggle) DeleteModeToggle.IsChecked = false;
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DrawModeToggle.IsChecked == true)
            {
                isDrawing = true;
                startPoint = e.GetPosition(DrawingCanvas);
                currentShape = new Line
                {
                    Stroke = brushColor,
                    StrokeThickness = brushSize,
                    X1 = startPoint.X,
                    Y1 = startPoint.Y,
                    X2 = startPoint.X,
                    Y2 = startPoint.Y
                };
                DrawingCanvas.Children.Add(currentShape);
            }
            else if (DeleteModeToggle.IsChecked == true)
            {

                Point clickPoint = e.GetPosition(DrawingCanvas);
                var clickedShape = GetShapeAtPoint(clickPoint);
                if (clickedShape != null)
                {
                    DrawingCanvas.Children.Remove(clickedShape);
                }
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && DrawModeToggle.IsChecked == true)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);
                if (currentShape is Line line)
                {
                    line.X2 = currentPoint.X;
                    line.Y2 = currentPoint.Y;
                }
            }
        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawing && DrawModeToggle.IsChecked == true)
            {
                isDrawing = false;
                currentShape = null;
            }
        }

        private Shape GetShapeAtPoint(Point point)
        {
            foreach (var child in DrawingCanvas.Children)
            {
                if (child is Shape shape)
                {

                    Rect bounds = new Rect(Canvas.GetLeft(shape), Canvas.GetTop(shape), shape.Width, shape.Height);
                    if (bounds.Contains(point))
                    {
                        return shape;
                    }
                }
            }
            return null;
        }
    }
}
      