/*
Author: Jiahao Sun
Class: ECE6122 QSZ
Last Date Modified: 12/07/2022
Description:
 This is an fragments file.
 This file initialized lights and pass to shader.
 
 references:
 https://learnopengl-cn.github.io
*/
#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D texture_diffuse1;

in vec3 Normal;
in vec3 FragPos;
  
uniform vec3 lightPos;
uniform vec3 viewPos;
uniform vec3 lightColor;
uniform vec3 objectColor;

void main()
{
    // this function initialize three types of light and combine them together
    
    // ambient
    float ambientStrength = 1;
    vec3 ambient = ambientStrength * lightColor;
      
    // diffuse
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * lightColor;
    
    // specular
    float specularStrength = 0.5;
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
    vec3 specular = specularStrength * spec * lightColor;
        
    vec3 result = (ambient + diffuse + specular);
    FragColor = texture(texture_diffuse1, TexCoords) * vec4(result, 1.0);
}
