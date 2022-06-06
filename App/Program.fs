open Layers.Dense
open Functions.Activation
open Data.Spiral
        
printfn "=============================="
printfn "NEURAL NETWORK FROM SCRATCH!!!"

let inputs = 2
let neurons = 32

let layer1 = LayerDense(inputs, neurons)
let layer2 = LayerDense(neurons, neurons)
let layer3 = LayerDense(neurons, 16)

let X, y = SpiralData 100 2

printfn "%A" (ReLU.Forward << layer3.Forward << ReLU.Forward << layer2.Forward << ReLU.Forward << layer1.Forward <| X)

System.Console.ReadKey() |> ignore