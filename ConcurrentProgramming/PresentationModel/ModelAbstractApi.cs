//__________________________________________________________________________________________
//
//  Copyright 2022 Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and to get started
//  comment using the discussion panel at
//  https://github.com/mpostol/TP/discussions/182
//  with an introduction of yourself and tell us about what you do with this community.
//__________________________________________________________________________________________

using System.Numerics;
using Logic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System.Collections.ObjectModel;

namespace TP.ConcurrentProgramming.PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Radius { get; }
        public abstract int Height { get; }
        public abstract int Width { get; }
        public abstract ObservableCollection<Ball> CreateBalls(int number);
        //public abstract void CreateBalls(int ballNumber);
        public abstract void Moving();
        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }
       // public abstract IList CreateBalls2(int ballNumber);

    }

    internal class ModelApi : ModelAbstractApi
    {
        private readonly Storage storage = new Storage();
        public override int Radius => storage.Generator.Radius;
        public override int Width => Storage.width;
        public override int Height => Storage.height;
        //public override void CreateBalls(int ballNumber) => storage.CreateBalls(ballNumber);
        //public override ObservableCollection<Ball> Balls => storage.Balls;
        public override void Moving() => storage.Moving();

        public override ObservableCollection<Ball> CreateBalls(int number)
        {
            storage.CreateBalls(number);
            foreach (var ball in storage.Balls)
            {
                // Trace.WriteLine("x");
                // Trace.WriteLine(ball.Coordinates.X);
                // Trace.WriteLine("y");
                // Trace.WriteLine(ball.Coordinates.Y);
                Trace.WriteLine("x");
                Trace.WriteLine(ball.X);
                Trace.WriteLine("y");
                Trace.WriteLine(ball.Y);
            }

            return storage.Balls;
        }

  

    }


}