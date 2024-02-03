package com.chichito.demoreactive;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.context.annotation.ComponentScan;

@SpringBootApplication
@EntityScan(basePackages = "com.example.demoreactive.models")
@ComponentScan(basePackages = "com.example.demoreactive")
public class DemoReactiveApplication {

	public static void main(String[] args) {
		SpringApplication.run(DemoReactiveApplication.class, args);
	}

}
