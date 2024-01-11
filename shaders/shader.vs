#version 330 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aColor;
layout (location = 2) in vec2 aTexCoord;
out vec4 vertexColor;
out vec3 ourColor;
out vec2 TexCoord;
uniform float deltaValue; // 在OpenGL程序代码中设定这个变量
uniform mat4 transform;

void main()
{
   gl_Position = vec4(aPos, 1.0) * transform;
   vertexColor = vec4(aColor, 1.0f);
   TexCoord = aTexCoord;
};