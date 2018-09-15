using UnityEngine;
using System.Collections;

[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public sealed class ES2_AudioClip : ES2Type
{
	public ES2_AudioClip() : base(typeof(AudioClip))
	{
		key = (byte)25;
	}
	
	public override void Write(object data, ES2Writer writer)
	{
		AudioClip param = (AudioClip)data;
		writer.writer.Write((byte)5);
		float[] samples = new float[param.samples * param.channels];
		param.GetData(samples, 0);
		writer.writer.Write(param.name);
		writer.writer.Write(param.samples);
		writer.writer.Write(param.channels);
		writer.writer.Write(param.frequency);
		writer.Write(samples);
	}
	
	public override object Read(ES2Reader reader)
	{
		AudioClip result = null;
		return result;
	}
}