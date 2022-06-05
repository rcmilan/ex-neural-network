namespace Functions

module NeuronMath = 
    open Types.NeuronTypes

    let dotWithBias (dotProducts: DotProduct seq) (bias : Bias seq) = 
        Seq.map2 (+) dotProducts bias 
        
    let private dotWeightsByInputs (weight : Weights) (input : Inputs) : DotProduct = Seq.fold2 (fun state i w -> state + i * w) LanguagePrimitives.GenericZero input weight

    let private dotWeitghtSeqByInputs (weightSequence : Weights seq) (inputs : Inputs) =
        weightSequence |> Seq.map(fun weights -> dotWeightsByInputs weights inputs)

    let private dotWeightSeqByInputSeq (weightSequence : Weights seq) (inputs : Inputs seq) =
        Seq.map (fun i -> dotWeitghtSeqByInputs weightSequence i) inputs

    let dot<'T> (w:obj) (i:obj)= 
        match (w, i) with 
        | (:? Weights as w0), (:? Inputs as i0) -> dotWeightsByInputs w0 i0 |> box
        | (:? seq<Weights> as w1), (:? Inputs as i1) -> dotWeitghtSeqByInputs w1 i1 |> box
        | (:? seq<Weights> as w2), (:? seq<Inputs> as i2) -> dotWeightSeqByInputSeq w2 i2 |> box
        | _ -> None |> box
        :?> 'T