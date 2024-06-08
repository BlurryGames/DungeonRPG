shader_type spatial;

render_mode unshaded, cull_disabled;

uniform sampler2D tex: source_color;
uniform vec4 flash_color: source_color = vec4(1.0f, 1.0f, 1.0f, 1.0f);
uniform bool active = false;

void fragment()
{
	vec4 color = texture(tex, UV);
	
	ALPHA = color.a;
	
	if (active)
	{
		color = flash_color;
	}
	
	ALBEDO = color.rgb;
}