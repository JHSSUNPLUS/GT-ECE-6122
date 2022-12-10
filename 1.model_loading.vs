/*
Author: Jiahao Sun
Class: ECE6122 QSZ
Last Date Modified: 12/07/2022
Description:
 This is an vs file.
 This file initialized lights and pass to shader.
 
 references:
 https://learnopengl-cn.github.io
*/

#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec2 aTexCoords;

out vec2 TexCoords;
out vec3 FragPos;
out vec3 Normal;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    // this function initialize three types of light and combine them together
    TexCoords = aTexCoords;
    
    FragPos = vec3(model * vec4(aPos, 1.0));
    Normal = mat3(transpose(inverse(model))) * aNormal;
    
    gl_Position = projection * view * model * vec4(aPos, 1.0);
}
