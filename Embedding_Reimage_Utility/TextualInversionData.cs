using System.Text.Json.Serialization;

namespace Embedding_Reimage_Utility {
	internal class TokenA {
		[JsonPropertyName("*")]
		public int Val { get; set; }
	}
	internal class TokenB {
		[JsonPropertyName("*")]
		public Tensor? Child { get; set; }
	}
	internal class Tensor {
		[JsonPropertyName("TORCHTENSOR")]
		public double[][] Tensors { get; set; } = new double[0][];
	}
	internal class TextualInversionData {
		[JsonPropertyName("name")]
		public string Name { get; set; } = "";
		[JsonPropertyName("step")]
		public int StepCount { get; set; }
		[JsonPropertyName("sd_checkpoint")]
		public string CheckpointHash { get; set; } = "";
		[JsonPropertyName("sd_checkpoint_name")]
		public string CheckpointName { get; set; } = "";
		[JsonPropertyName("string_to_token")]
		public TokenA? Unknown { get; set; }
		[JsonPropertyName("string_to_param")]
		public TokenB? Tensors { get; set; }
	}
}
