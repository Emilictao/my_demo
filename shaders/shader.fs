#version 330 core
out vec4 FragColor;
in vec4 vertexColor;
in vec2 TexCoord;
uniform float mixDelta;
uniform sampler2D texture1;
uniform sampler2D texture2;

float sdfEdge(vec2 p){
	return max(p.x, p.y);
}

float dis(vec2 p1, vec2 p2){
	return sqrt((p1.x - p2.x)*(p1.x - p2.x) + (p1.y - p2.y)*(p1.y - p2.y));
}

void main()
{
	float d = dis(TexCoord, vec2(0.5, 0.5));
	vec2 deviation = vec2(abs(0.5 - TexCoord.x), abs(0.5 - TexCoord.y))/mixDelta;
	//FragColor = mix(texture(texture1, TexCoord), texture(texture2, (vec2(TexCoord.x, TexCoord.y) + deviation)), mixDelta * 1);
	FragColor = texture(texture2, normalize(TexCoord - vec2(0.5,0.5)) * mixDelta / (d * d));
	//FragColor = texture(texture2, normalize(TexCoord) * mixDelta / d + TexCoord);
	//FragColor = mix(texture(texture1, TexCoord), texture(texture2, TexCoord), mixDelta * 1);
};