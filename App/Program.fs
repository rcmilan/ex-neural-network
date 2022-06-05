type Inputs = float seq
type Weights = float seq
type Bias = float
type DotProduct = float

let dotWithBias (dotProducts: DotProduct seq) (bias : Bias seq) = 
    Seq.map2 (+) dotProducts bias 

let dot (weightSequence : Weights seq) (inputs : Inputs) =

    let dot (weight : Weights) (input : Inputs) = Seq.fold2 (fun state i w -> state + i * w) LanguagePrimitives.GenericZero input weight
    
    weightSequence |> Seq.map(fun weights -> dot weights inputs)

printfn "=============================="
printfn "NEURAL NETWORK FROM SCRATCH!!!"

let inputs : Inputs = [| 1.0; 2.0; 3.0; 2.5 |]

let weightsSeq : Weights seq = [|
        [|0.2; 0.8; -0.5; 1.0|];
        [|0.5; -0.91; 0.26; -0.5|];
        [|-0.26; -0.27; 0.17; 0.87|]
    |]

let bias : Bias seq = [| 2.0;3.0;0.5 |]

let dps : DotProduct seq = (dot weightsSeq inputs) 

printfn "RESULTADO DA CAMADA!!!"
Seq.iter (printfn "\t%A") (dotWithBias dps bias)

System.Console.ReadKey() |> ignore