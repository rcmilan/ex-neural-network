namespace Functions

module NeuronMath =
    let dotWithBias (dotProducts: float seq) (bias : float seq) : float seq = 
        Seq.map2 (+) dotProducts bias 
        
    let private dotWeightsByInputs (weight : float seq) (input : float seq) : float = Seq.fold2 (fun state i w -> state + i * w) LanguagePrimitives.GenericZero input weight

    let private dotWeitghtSeqByInputs (weightSequence : float seq seq) (inputs : float seq) =
        weightSequence |> Seq.map(fun weights -> dotWeightsByInputs weights inputs)

    let private dotWeightSeqByInputSeq (weightSequence : float seq seq) (inputs : float seq seq) =
        Seq.map (fun i -> dotWeitghtSeqByInputs weightSequence i) inputs

    let dot<'T> (w:obj) (i:obj)= 
        match (w, i) with 
        | (:? seq<seq<float>> as w2), (:? seq<seq<float>> as i2) -> dotWeightSeqByInputSeq w2 i2 |> box
        | (:? seq<seq<float>> as w1), (:? seq<float> as i1) -> dotWeitghtSeqByInputs w1 i1 |> box
        | (:? seq<float> as w0), (:? seq<float> as i0) -> dotWeightsByInputs w0 i0 |> box
        | _ -> None |> box
        :?> 'T