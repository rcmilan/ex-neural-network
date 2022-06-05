open Functions.NeuronMath

printfn "=============================="
printfn "NEURAL NETWORK FROM SCRATCH!!!"

let inputs : seq<float> seq = [|
        [| 1.0; 2.0; 3.0; 2.5 |];
        [|2.0; 5.0; -1.0; 2.0|];
        [|-1.5; 2.7; 3.3; -0.8|]
    |]

let weightsSeq : seq<float> seq = [|
        [|0.2; 0.8; -0.5; 1.0|];
        [|0.5; -0.91; 0.26; -0.5|];
        [|-0.26; -0.27; 0.17; 0.87|]
    |]

let bias : seq<float> = [| 2.0; 3.0; 0.5 |]


let weightsSeq2 : seq<float> seq = [|
        [|0.1; -0.14; 0.5;|];
        [|-0.5; 0.12; -0.33;|];
        [|-0.44; 0.73; -0.13;|]
    |]

let bias2 : seq<float> = [| -1.0; 2.0; -0.5 |]

let result = dot<float seq seq> weightsSeq inputs
                |> Seq.map(fun f -> dotWithBias f bias) // Resultado da camada 1
                |> dot<float seq seq> weightsSeq2
                |> Seq.map(fun f -> dotWithBias f bias2) // Resultado da camada 2

for a in result do 
    for b in a do
        printf "%A\t" b
    printf "\n"
    

System.Console.ReadKey() |> ignore