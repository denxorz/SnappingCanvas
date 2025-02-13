﻿using System.ComponentModel;

namespace Denxorz.InputOutputSnappingCanvas;

public partial class OutputControl : INotifyPropertyChanged, IConnectionOutput
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler<OutputConnectionChangedEventArgs>? ConnectionChanged;

    private IConnectionInput? snappedInput;

    public IConnectionInput? ConnectedInput
    {
        get { return snappedInput; }
        set
        {
            if (snappedInput != value)
            {
                var oldInput = snappedInput;
                snappedInput = value;
                PropertyChanged?.Invoke(this, new(nameof(ConnectedInput)));
                ConnectionChanged?.Invoke(this, new(Context, oldInput?.Context, snappedInput?.Context));
            }
        }
    }

    public object? Context { get; set; }

    public OutputControl()
    {
        InitializeComponent();
        DataContext = this;
    }
}
